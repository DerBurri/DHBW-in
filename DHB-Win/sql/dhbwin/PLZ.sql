create table dhbwin.PLZ
(
    PLZ int not null
        constraint PLZ_pk
            primary key nonclustered,
    Ort char(30)
)
    go

create unique index PLZ_PLZ_uindex
    on dhbwin.PLZ (PLZ) go

    go

