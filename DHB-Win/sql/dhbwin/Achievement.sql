create table dhbwin.Achievement
(
    AchID       int identity
        constraint Achievement_pk
        primary key nonclustered,
    Title       char(100),
    Description char(500),
    ExpPoints   int,
    Reward      int
)
    go

create unique index Achievement_AchID_uindex
    on dhbwin.Achievement (AchID) go

go

