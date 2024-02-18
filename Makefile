ASSEMBLER = z80-unknown-coff-as
LINKER = z80-unknown-coff-ld
OBJCOPY = z80-unknown-coff-objcopy

ASFLAGS = -a
LDFLAGS =

LD_FILES := $(wildcard *.ld)
SRC_ASM := $(wildcard *.asm)
OBJ_FILES := $(patsubst %.asm,%.out,$(SRC_ASM))

all: rom.bin ram.hex

rom.bin: rom.out
	$(OBJCOPY) -O binary -j.rom $< $@

ram.hex: ram.out
	$(OBJCOPY) -O ihex -j.ram $< $@

rom.out: $(OBJ_FILES) $(LD_FILES)
	$(LINKER) $(LDFLAGS) -T rom.ld -Map=rom.map $(OBJ_FILES) -o $@

ram.out: $(OBJ_FILES) $(LD_FILES)
	$(LINKER) $(LDFLAGS) -T ram.ld -Map=ram.map $(OBJ_FILES) -o $@

%.out: %.asm
	$(ASSEMBLER) $(ASFLAGS) $< -o $@ > $<.lst

clean:
	rm -f *.hex *.out *.bin *.map *.lst
