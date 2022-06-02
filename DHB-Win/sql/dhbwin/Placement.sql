create table dhbwin.Placement
(
    PlacementID int identity,
    BetID_fk    int not null
        constraint Bet_fk
            references dhbwin.Bet,
    UID_fk      int not null
        constraint User_fk
            references dhbwin.[ User],
    OptionID_fk int
        constraint Placement_BetOptions_OptionsID_fk
            references dhbwin.BetOptions,
    constraint Placement_pk
        primary key nonclustered (UID_fk, PlacementID, BetID_fk)
)
    go

create unique index Placement_PlacementID_uindex
    on dhbwin.Placement (PlacementID)
    go

create unique index Placement_BetID_fk_uindex
    on dhbwin.Placement (BetID_fk)
    go

create unique index Placement_UID_fk_uindex
    on dhbwin.Placement (UID_fk) go

(UID_fk)
    go

