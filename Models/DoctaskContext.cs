using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace doc_task.Models;

public partial class DoctaskContext : DbContext
{
    public DoctaskContext()
    {
    }

    public DoctaskContext(DbContextOptions<DoctaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Frequency> Frequencies { get; set; }

    public virtual DbSet<FrequencyDetail> FrequencyDetails { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Org> Orgs { get; set; }

    public virtual DbSet<Period> Periods { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Progress> Progresses { get; set; }

    public virtual DbSet<Reminder> Reminders { get; set; }

    public virtual DbSet<Reminderunit> Reminderunits { get; set; }

    public virtual DbSet<Reportsummary> Reportsummaries { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<Taskunitassignment> Taskunitassignments { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<Unituser> Unitusers { get; set; }

    public virtual DbSet<Uploadfile> Uploadfiles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userrole> Userroles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=doctask;User Id=sa;Password=123123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Frequency>(entity =>
        {
            entity.HasKey(e => e.FrequencyId).HasName("PK__frequenc__AA1CD55760D41976");

            entity.ToTable("frequency");

            entity.Property(e => e.FrequencyId).HasColumnName("frequencyId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.FrequencyDetail)
                .HasMaxLength(100)
                .HasColumnName("frequencyDetail");
            entity.Property(e => e.FrequencyType)
                .HasMaxLength(10)
                .HasColumnName("frequencyType");
            entity.Property(e => e.IntervalValue).HasColumnName("intervalValue");
        });

        modelBuilder.Entity<FrequencyDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__frequenc__3213E83FD3F362E2");

            entity.ToTable("frequency_detail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DayOfMonth).HasColumnName("dayOfMonth");
            entity.Property(e => e.DayOfWeek).HasColumnName("dayOfWeek");
            entity.Property(e => e.FrequencyId).HasColumnName("frequencyId");

            entity.HasOne(d => d.Frequency).WithMany(p => p.FrequencyDetails)
                .HasForeignKey(d => d.FrequencyId)
                .HasConstraintName("fk_frequency_detail_frequency");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__notifica__4BA5CEA99BF8EE89");

            entity.ToTable("notification");

            entity.Property(e => e.NotificationId).HasColumnName("notificationId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.IsRead).HasColumnName("isRead");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.TaskId).HasColumnName("taskId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Task).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fkNotificationTask");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fkNotificationUser");
        });

        modelBuilder.Entity<Org>(entity =>
        {
            entity.HasKey(e => e.OrgId).HasName("PK__org__3581FB98E1151683");

            entity.ToTable("org");

            entity.Property(e => e.OrgId).HasColumnName("orgId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.OrgName)
                .HasMaxLength(100)
                .HasColumnName("orgName");
            entity.Property(e => e.ParentOrgId).HasColumnName("parentOrgId");

            entity.HasOne(d => d.ParentOrg).WithMany(p => p.InverseParentOrg)
                .HasForeignKey(d => d.ParentOrgId)
                .HasConstraintName("fkOrgParent");
        });

        modelBuilder.Entity<Period>(entity =>
        {
            entity.HasKey(e => e.PeriodId).HasName("PK__period__2785D0987E08D744");

            entity.ToTable("period");

            entity.Property(e => e.PeriodId).HasColumnName("periodId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.PeriodName)
                .HasMaxLength(50)
                .HasColumnName("periodName");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__position__B07CF5AE234132B8");

            entity.ToTable("position");

            entity.Property(e => e.PositionId).HasColumnName("positionId");
            entity.Property(e => e.PositionName)
                .HasMaxLength(255)
                .HasColumnName("positionName");
        });

        modelBuilder.Entity<Progress>(entity =>
        {
            entity.HasKey(e => e.ProgressId).HasName("PK__progress__0F2BDC7D4676D419");

            entity.ToTable("progress");

            entity.Property(e => e.ProgressId).HasColumnName("progressId");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Feedback).HasColumnName("feedback");
            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .HasColumnName("fileName");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .HasColumnName("filePath");
            entity.Property(e => e.PercentageComplete).HasColumnName("percentageComplete");
            entity.Property(e => e.PeriodId).HasColumnName("periodId");
            entity.Property(e => e.Proposal).HasColumnName("proposal");
            entity.Property(e => e.Result).HasColumnName("result");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TaskId).HasColumnName("taskId");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");

            entity.HasOne(d => d.Period).WithMany(p => p.Progresses)
                .HasForeignKey(d => d.PeriodId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fkProgressPeriod");

            entity.HasOne(d => d.Task).WithMany(p => p.Progresses)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("fkProgressTask");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.Progresses)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fkProgressUpdatedBy");
        });

        modelBuilder.Entity<Reminder>(entity =>
        {
            entity.HasKey(e => e.Reminderid).HasName("PK__reminder__09D5AEDB83AF44E9");

            entity.ToTable("reminder");

            entity.Property(e => e.Reminderid).HasColumnName("reminderid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdat");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Isauto).HasColumnName("isauto");
            entity.Property(e => e.Isnotified).HasColumnName("isnotified");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.Notificationid).HasColumnName("notificationid");
            entity.Property(e => e.Notifiedat)
                .HasColumnType("datetime")
                .HasColumnName("notifiedat");
            entity.Property(e => e.Periodid).HasColumnName("periodid");
            entity.Property(e => e.Taskid).HasColumnName("taskid");
            entity.Property(e => e.Triggertime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("triggertime");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.Reminders)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("reminder_fk_user");

            entity.HasOne(d => d.Notification).WithMany(p => p.Reminders)
                .HasForeignKey(d => d.Notificationid)
                .HasConstraintName("reminder_fk_notification");

            entity.HasOne(d => d.Period).WithMany(p => p.Reminders)
                .HasForeignKey(d => d.Periodid)
                .HasConstraintName("reminder_fk_period");

            entity.HasOne(d => d.Task).WithMany(p => p.Reminders)
                .HasForeignKey(d => d.Taskid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reminder_fk_task");
        });

        modelBuilder.Entity<Reminderunit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reminder__3213E83F021C4DE0");

            entity.ToTable("reminderunit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Reminderid).HasColumnName("reminderid");
            entity.Property(e => e.Unitid).HasColumnName("unitid");

            entity.HasOne(d => d.Reminder).WithMany(p => p.Reminderunits)
                .HasForeignKey(d => d.Reminderid)
                .HasConstraintName("fk_reminder");

            entity.HasOne(d => d.Unit).WithMany(p => p.Reminderunits)
                .HasForeignKey(d => d.Unitid)
                .HasConstraintName("fk_unit");
        });

        modelBuilder.Entity<Reportsummary>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__reportsu__1C9B4E2D9529701A");

            entity.ToTable("reportsummary");

            entity.Property(e => e.ReportId).HasColumnName("reportId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.PeriodId).HasColumnName("periodId");
            entity.Property(e => e.ReportFile).HasColumnName("reportFile");
            entity.Property(e => e.Summary).HasColumnName("summary");
            entity.Property(e => e.TaskId).HasColumnName("taskId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Reportsummaries)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fkReportCreatedBy");

            entity.HasOne(d => d.Period).WithMany(p => p.Reportsummaries)
                .HasForeignKey(d => d.PeriodId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fkReportPeriod");

            entity.HasOne(d => d.ReportFileNavigation).WithMany(p => p.Reportsummaries)
                .HasForeignKey(d => d.ReportFile)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fkReportFile");

            entity.HasOne(d => d.Task).WithMany(p => p.Reportsummaries)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fkReportTask");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("PK__role__CD994BF20472A4B4");

            entity.ToTable("role");

            entity.HasIndex(e => e.Rolename, "UQ__role__4685A062182ED87A").IsUnique();

            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdat");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Rolename)
                .HasMaxLength(100)
                .HasColumnName("rolename");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__task__DD5D5A4202A7DCB6");

            entity.ToTable("task");

            entity.Property(e => e.TaskId).HasColumnName("taskId");
            entity.Property(e => e.AssigneeId).HasColumnName("assigneeId");
            entity.Property(e => e.AssignerId).HasColumnName("assignerId");
            entity.Property(e => e.AttachedFile).HasColumnName("attachedFile");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DueDate).HasColumnName("dueDate");
            entity.Property(e => e.FrequencyId).HasColumnName("frequencyId");
            entity.Property(e => e.OrgId).HasColumnName("orgId");
            entity.Property(e => e.ParentTaskId).HasColumnName("parentTaskId");
            entity.Property(e => e.Percentagecomplete).HasColumnName("percentagecomplete");
            entity.Property(e => e.PeriodId).HasColumnName("periodId");
            entity.Property(e => e.Priority)
                .HasMaxLength(10)
                .HasDefaultValue("medium")
                .HasColumnName("priority");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("pending")
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UnitId).HasColumnName("unitId");

            entity.HasOne(d => d.Assignee).WithMany(p => p.TaskAssignees)
                .HasForeignKey(d => d.AssigneeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fkTaskAssignee");

            entity.HasOne(d => d.Assigner).WithMany(p => p.TaskAssigners)
                .HasForeignKey(d => d.AssignerId)
                .HasConstraintName("fkTaskAssigner");

            entity.HasOne(d => d.Frequency).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.FrequencyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_taskitem_frequency");

            entity.HasOne(d => d.Org).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.OrgId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fkTaskOrg");

            entity.HasOne(d => d.Period).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.PeriodId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fkTaskPeriod");

            entity.HasMany(d => d.Users).WithMany(p => p.Tasks)
                .UsingEntity<Dictionary<string, object>>(
                    "Taskassignee",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_taskassignees_User"),
                    l => l.HasOne<Task>().WithMany()
                        .HasForeignKey("TaskId")
                        .HasConstraintName("fk_taskassignees_Task"),
                    j =>
                    {
                        j.HasKey("TaskId", "UserId");
                        j.ToTable("taskassignees");
                    });
        });

        modelBuilder.Entity<Taskunitassignment>(entity =>
        {
            entity.HasKey(e => e.TaskUnitAssignmentId).HasName("PK__taskunit__C51468A498772EA8");

            entity.ToTable("taskunitassignment");

            entity.HasOne(d => d.Task).WithMany(p => p.Taskunitassignments)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("fk_taskunit_Task");

            entity.HasOne(d => d.Unit).WithMany(p => p.Taskunitassignments)
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("fk_taskunit_Unit");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.UnitId).HasName("PK__unit__55D7923551981B32");

            entity.ToTable("unit");

            entity.Property(e => e.UnitId).HasColumnName("unitId");
            entity.Property(e => e.OrgId).HasColumnName("orgId");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .HasColumnName("type");
            entity.Property(e => e.UnitName)
                .HasMaxLength(255)
                .HasColumnName("unitName");
            entity.Property(e => e.UnitParent).HasColumnName("unitParent");

            entity.HasOne(d => d.Org).WithMany(p => p.Units)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("fkUnitOrg");

            entity.HasOne(d => d.UnitParentNavigation).WithMany(p => p.InverseUnitParentNavigation)
                .HasForeignKey(d => d.UnitParent)
                .HasConstraintName("fkUnitParent");
        });

        modelBuilder.Entity<Unituser>(entity =>
        {
            entity.HasKey(e => e.UnitUserId).HasName("PK__unituser__0DD6FE7B824C9A90");

            entity.ToTable("unituser");

            entity.Property(e => e.UnitUserId).HasColumnName("unitUserId");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.UnitId).HasColumnName("unitId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Unit).WithMany(p => p.Unitusers)
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("fkUnitUserUnit");

            entity.HasOne(d => d.User).WithMany(p => p.Unitusers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkUnitUserUser");
        });

        modelBuilder.Entity<Uploadfile>(entity =>
        {
            entity.HasKey(e => e.FileId).HasName("PK__uploadfi__C2C6FFDC8D4E20DE");

            entity.ToTable("uploadfile");

            entity.Property(e => e.FileId).HasColumnName("fileId");
            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .HasColumnName("fileName");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .HasColumnName("filePath");
            entity.Property(e => e.UploadedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("uploadedAt");
            entity.Property(e => e.UploadedBy).HasColumnName("uploadedBy");

            entity.HasOne(d => d.UploadedByNavigation).WithMany(p => p.Uploadfiles)
                .HasForeignKey(d => d.UploadedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fkUploadFileUploadedBy");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__user__CB9A1CFFE10E5BA5");

            entity.ToTable("user");

            entity.HasIndex(e => e.Email, "UQ__user__AB6E61645425B983").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__user__F3DBC572960EC2FF").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("fullName");
            entity.Property(e => e.OrgId).HasColumnName("orgId");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.PositionId).HasColumnName("positionId");
            entity.Property(e => e.PositionName)
                .HasMaxLength(255)
                .HasColumnName("positionName");
            entity.Property(e => e.Refreshtoken)
                .HasMaxLength(255)
                .HasColumnName("refreshtoken");
            entity.Property(e => e.Refreshtokenexpirytime)
                .HasColumnType("datetime")
                .HasColumnName("refreshtokenexpirytime");
            entity.Property(e => e.Role)
                .HasMaxLength(11)
                .HasDefaultValue("0")
                .HasColumnName("role");
            entity.Property(e => e.UnitId).HasColumnName("unitId");
            entity.Property(e => e.UnitUserId).HasColumnName("unitUserId");
            entity.Property(e => e.UserParent).HasColumnName("userParent");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Org).WithMany(p => p.Users)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("user_ibfk_2");

            entity.HasOne(d => d.Position).WithMany(p => p.Users)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("user_ibfk_1");

            entity.HasOne(d => d.Unit).WithMany(p => p.Users)
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("user_ibfk_3");

            entity.HasOne(d => d.UnitUser).WithMany(p => p.Users)
                .HasForeignKey(d => d.UnitUserId)
                .HasConstraintName("fk_user_unitUser");

            entity.HasOne(d => d.UserParentNavigation).WithMany(p => p.InverseUserParentNavigation)
                .HasForeignKey(d => d.UserParent)
                .HasConstraintName("user_ibfk_4");
        });

        modelBuilder.Entity<Userrole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__userrole__3213E83FFA20CE99");

            entity.ToTable("userrole");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdat");
            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Role).WithMany(p => p.Userroles)
                .HasForeignKey(d => d.Roleid)
                .HasConstraintName("fk_userrole_role");

            entity.HasOne(d => d.User).WithMany(p => p.Userroles)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("fk_userrole_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
