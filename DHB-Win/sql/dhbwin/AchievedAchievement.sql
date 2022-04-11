use dhbwin
go

create table dhbwin.AchievedAchievement
(
    UID_fk   int not null
        constraint User_AchievedAchievement___fk
            references dhbwin.[User],
    AchID_fk int identity
        constraint AchievedAchievement_Achievement_AchID_fk
            references dhbwin.Achievement,
    constraint AchievedAchievement_pk
        primary key nonclustered (AchID_fk, UID_fk)
)
go

create unique index AchievedAchievement_AchID_fk_uindex
    on dhbwin.AchievedAchievement (AchID_fk)
go

