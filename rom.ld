INCLUDE memory.ld

SECTIONS
{
    .rom : {
        *(.bios)
        . = ABSOLUTE(0x0150);
        *(.cold)
        . = ABSOLUTE(0x0153);
        *(.warm)
    } > rom
    .ram : {
        . = ABSOLUTE(0xFE00);
        *(.bss)
    } > ram
}
