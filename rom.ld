INCLUDE memory.ld

SECTIONS
{
    . = 0x0000; /* Start address of the .text section */
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
