create table dhbwin.Job
(
    JobID       int identity
        constraint Job_pk
        primary key nonclustered,
    ProviderID  int
        constraint Job_User_UID_fk
            references dhbwin.[ User],
    WorkerID    int
        constraint Job_worker_fk
            references dhbwin.[ User],
    Title       char(50),
    Description char(50),
    Reward      int,
    ExpPoints   int
) go

exec sp_addextendedproperty 'MS_Description', 'Create jobs with Betcoins', 'SCHEMA', 'dhbwin', 'TABLE', 'Job'
go

create unique index Job_JobID_uindex
    on dhbwin.Job (JobID)
    go

