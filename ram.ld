INCLUDE memory.ld

SECTIONS
{
    .rom : {
        *(.bios)
    } > rom
    .ram : {
        *(.cold .warm)
    } > ram
    .bss : {
        . = ABSOLUTE(0xFA00);
        *(.bss)
    } > ram
    .scmon : { /* reserved for SCM */
        . = ABSOLUTE(0xFC00);
    }
}
