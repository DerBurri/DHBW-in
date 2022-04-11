create table dhbwin.BetOptions
(
    OptionsID    int identity
        constraint BetOptions_pk
        primary key nonclustered,
    BetID        int
        constraint BetOptions_Bet_BetID_fk
            references dhbwin.Bet,
    Title        char(50),
    Descpription char(500),
    QuoteValue   int
)
    go

create unique index BetOptions_OptionsID_uindex
    on dhbwin.BetOptions (OptionsID)
    go

