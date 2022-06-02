create table dhbwin.Bet
(
    BetID       int identity
        constraint Bet_pk
        primary key nonclustered,
    UID_fk2     int not null
        constraint UID_fk2
            references dhbwin.[ User],
    Title       char(50),
    ExpPoints   int,
    Reward      int,
    Description char(500)
)
    go

create unique index Bet_BetID_uindex
    on dhbwin.Bet (BetID) go

 go

