using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class LearningSystemContext : DbContext
{
    public LearningSystemContext()
    {
    }

    public LearningSystemContext(DbContextOptions<LearningSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<AnswerKey> AnswerKeys { get; set; }

    public virtual DbSet<Answered> Answereds { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<Calendar> Calendars { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Competency> Competencies { get; set; }

    public virtual DbSet<Content> Contents { get; set; }

    public virtual DbSet<ContentType> ContentTypes { get; set; }

    public virtual DbSet<Correlation> Correlations { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CoursesPackage> CoursesPackages { get; set; }

    public virtual DbSet<CoursesPlatform> CoursesPlatforms { get; set; }

    public virtual DbSet<CoursesSubject> CoursesSubjects { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DocumentAnnotation> DocumentAnnotations { get; set; }

    public virtual DbSet<DocumentCorrection> DocumentCorrections { get; set; }

    public virtual DbSet<DocumentQuestion> DocumentQuestions { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<ExchangeToken> ExchangeTokens { get; set; }

    public virtual DbSet<Front> Fronts { get; set; }

    public virtual DbSet<Gap> Gaps { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<Mock> Mocks { get; set; }

    public virtual DbSet<MockQuestion> MockQuestions { get; set; }

    public virtual DbSet<MockResult> MockResults { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<Performed> Performeds { get; set; }

    public virtual DbSet<Period> Periods { get; set; }

    public virtual DbSet<Platform> Platforms { get; set; }

    public virtual DbSet<Proficiency> Proficiencies { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<ProfileActivity> ProfileActivities { get; set; }

    public virtual DbSet<ProfilesSchoolsPackage> ProfilesSchoolsPackages { get; set; }

    public virtual DbSet<Progress> Progresses { get; set; }

    public virtual DbSet<Quest> Quests { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<QuestsQuestion> QuestsQuestions { get; set; }

    public virtual DbSet<QuestsSubject> QuestsSubjects { get; set; }

    public virtual DbSet<Record> Records { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<SchoolsPackage> SchoolsPackages { get; set; }

    public virtual DbSet<SchoolsPackagesLesson> SchoolsPackagesLessons { get; set; }

    public virtual DbSet<SchoolsPlatform> SchoolsPlatforms { get; set; }

    public virtual DbSet<SchoolsStudent> SchoolsStudents { get; set; }

    public virtual DbSet<Strip> Strips { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Veritable> Veritables { get; set; }

    public virtual DbSet<ViewDocumentosFeito> ViewDocumentosFeitos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=irium.database.windows.net;Database=learning_system;User Id=irium;Password=@E+*R(j}t#GL9Ed;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.ToTable("Activity", "hub");

            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.Message).HasColumnType("text");

            entity.HasOne(d => d.Category).WithMany(p => p.Activities)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Activity_Categories");

            entity.HasOne(d => d.Package).WithMany(p => p.Activities)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Activity_Packages");

            entity.HasOne(d => d.Schedule).WithMany(p => p.Activities)
                .HasForeignKey(d => d.ScheduleId)
                .HasConstraintName("FK_Activity_Calendar");
        });

        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Answers");

            entity.HasIndex(e => e.QuestionId, "IX_QuestionId");

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK_dbo.Answers_dbo.Questions_QuestionId");
        });

        modelBuilder.Entity<AnswerKey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AnswerKeys");

            entity.HasIndex(e => e.AnswerId, "IX_AnswerId");

            entity.HasOne(d => d.Answer).WithMany(p => p.AnswerKeys)
                .HasForeignKey(d => d.AnswerId)
                .HasConstraintName("FK_dbo.AnswerKeys_dbo.Answers_AnswerId");
        });

        modelBuilder.Entity<Answered>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Answered");

            entity.ToTable("Answered");

            entity.HasIndex(e => e.ProgressId, "IX_ProgressId");

            entity.HasIndex(e => new { e.ProfileId, e.QuestionId, e.Result }, "nci_wi_Answered_99963E08376CCDB21C800D748C6987FF");

            entity.HasOne(d => d.Progress).WithMany(p => p.Answereds)
                .HasForeignKey(d => d.ProgressId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_dbo.Answered_dbo.Progress_ProgressId");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetRoles");

            entity.HasIndex(e => e.Name, "RoleNameIndex").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUsers");

            entity.HasIndex(e => e.ProfileId, "IX_Profile_Id");

            entity.HasIndex(e => e.UserName, "UserNameIndex").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");
            entity.Property(e => e.ProfileId).HasColumnName("Profile_Id");
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasOne(d => d.Profile).WithMany(p => p.AspNetUsers)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("FK_dbo.AspNetUsers_dbo.Profiles_Profile_Id");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK_dbo.AspNetUserRoles");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_RoleId");
                        j.HasIndex(new[] { "UserId" }, "IX_UserId");
                        j.IndexerProperty<string>("UserId").HasMaxLength(128);
                        j.IndexerProperty<string>("RoleId").HasMaxLength(128);
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUserClaims");

            entity.HasIndex(e => e.UserId, "IX_UserId");

            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId }).HasName("PK_dbo.AspNetUserLogins");

            entity.HasIndex(e => e.UserId, "IX_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);
            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<Calendar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Calendar_1");

            entity.ToTable("Calendar", "hub");

            entity.HasOne(d => d.Activity).WithMany(p => p.Calendars)
                .HasForeignKey(d => d.ActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calendar_Activity");

            entity.HasOne(d => d.Category).WithMany(p => p.Calendars)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Calendar_Categories");

            entity.HasOne(d => d.Package).WithMany(p => p.Calendars)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calendar_Packages1");

            entity.HasOne(d => d.Schedule).WithMany(p => p.Calendars)
                .HasForeignKey(d => d.ScheduleId)
                .HasConstraintName("FK_Calendar_Schedule");

            entity.HasOne(d => d.School).WithMany(p => p.Calendars)
                .HasForeignKey(d => d.SchoolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calendar_Schools");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Categories");

            entity.HasOne(d => d.Front).WithMany(p => p.Categories)
                .HasForeignKey(d => d.FrontId)
                .HasConstraintName("FK_Categories_Fronts");
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Characters");

            entity.HasIndex(e => e.ProfileId, "IX_ProfileId");

            entity.HasOne(d => d.Profile).WithMany(p => p.Characters)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("FK_dbo.Characters_dbo.Profiles_ProfileId");
        });

        modelBuilder.Entity<Competency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Competencies");
        });

        modelBuilder.Entity<Content>(entity =>
        {
            entity.ToTable("Content", "hub");

            entity.Property(e => e.Description).HasColumnType("text");

            entity.HasOne(d => d.Activity).WithMany(p => p.Contents)
                .HasForeignKey(d => d.ActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Content_Activity");

            entity.HasOne(d => d.ContentType).WithMany(p => p.Contents)
                .HasForeignKey(d => d.ContentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Content_ContentType");
        });

        modelBuilder.Entity<ContentType>(entity =>
        {
            entity.ToTable("ContentType", "hub");

            entity.Property(e => e.Label).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<Correlation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Correlations");

            entity.HasIndex(e => e.AnswerId, "IX_AnswerId");

            entity.HasOne(d => d.Answer).WithMany(p => p.Correlations)
                .HasForeignKey(d => d.AnswerId)
                .HasConstraintName("FK_dbo.Correlations_dbo.Answers_AnswerId");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Courses");

            entity.HasIndex(e => e.CategoryId, "IX_CategoryId");

            entity.HasOne(d => d.Category).WithMany(p => p.Courses)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_dbo.Courses_dbo.Categories_CategoryId");
        });

        modelBuilder.Entity<CoursesPackage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.CoursesPackages");

            entity.HasIndex(e => e.CourseId, "IX_CourseId");

            entity.HasIndex(e => e.PackageId, "IX_PackageId");

            entity.HasOne(d => d.Course).WithMany(p => p.CoursesPackages)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_dbo.CoursesPackages_dbo.Courses_CourseId");

            entity.HasOne(d => d.Package).WithMany(p => p.CoursesPackages)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK_dbo.CoursesPackages_dbo.Packages_PackageId");
        });

        modelBuilder.Entity<CoursesPlatform>(entity =>
        {
            entity.ToTable("CoursesPlatform", "hub");

            entity.HasOne(d => d.Course).WithMany(p => p.CoursesPlatforms)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CoursesPlatform_Courses");

            entity.HasOne(d => d.Platform).WithMany(p => p.CoursesPlatforms)
                .HasForeignKey(d => d.PlatformId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CoursesPlatform_Platform");
        });

        modelBuilder.Entity<CoursesSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.CoursesSubjects");

            entity.HasIndex(e => e.CourseId, "IX_CourseId");

            entity.HasIndex(e => e.SubjectId, "IX_SubjectId");

            entity.HasOne(d => d.Course).WithMany(p => p.CoursesSubjects)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_dbo.CoursesSubjects_dbo.Courses_CourseId");

            entity.HasOne(d => d.Subject).WithMany(p => p.CoursesSubjects)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK_dbo.CoursesSubjects_dbo.Subjects_SubjectId");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasOne(d => d.Course).WithMany(p => p.Documents)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_Documents_Courses");

            entity.HasOne(d => d.Type).WithMany(p => p.Documents)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK_Documents_DocumentTypes");
        });

        modelBuilder.Entity<DocumentAnnotation>(entity =>
        {
            entity.Property(e => e.Annotation).HasColumnType("text");
            entity.Property(e => e.Created).HasColumnType("datetime");

            entity.HasOne(d => d.Document).WithMany(p => p.DocumentAnnotations)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK_DocumentAnnotations_Documents");

            entity.HasOne(d => d.DocumentQuestion).WithMany(p => p.DocumentAnnotations)
                .HasForeignKey(d => d.DocumentQuestionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DocumentAnnotations_DocumentQuestions1");

            entity.HasOne(d => d.Profile).WithMany(p => p.DocumentAnnotations)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("FK_DocumentAnnotations_DocumentQuestions");
        });

        modelBuilder.Entity<DocumentCorrection>(entity =>
        {
            entity.Property(e => e.Correction).HasColumnType("text");

            entity.HasOne(d => d.DocumentAnnotation).WithMany(p => p.DocumentCorrections)
                .HasForeignKey(d => d.DocumentAnnotationId)
                .HasConstraintName("FK_DocumentCorrections_DocumentAnnotations");

            entity.HasOne(d => d.Profile).WithMany(p => p.DocumentCorrections)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("FK_DocumentCorrections_Profiles");
        });

        modelBuilder.Entity<DocumentQuestion>(entity =>
        {
            entity.Property(e => e.Enunciation).HasColumnType("text");

            entity.HasOne(d => d.Document).WithMany(p => p.DocumentQuestions)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK_DocumentQuestions_Documents");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ExchangeToken>(entity =>
        {
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TokenId)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Front>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Gap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Gaps");

            entity.HasIndex(e => e.AnswerId, "IX_Answer_Id");

            entity.HasIndex(e => e.QuestionId, "IX_QuestionId");

            entity.HasOne(d => d.Answer).WithMany(p => p.Gaps)
                .HasForeignKey(d => d.AnswerId)
                .HasConstraintName("FK_dbo.Gaps_dbo.Answers_Answer_Id");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Grades");

            entity.HasIndex(e => e.ProgressId, "IX_ProgressId");

            entity.HasIndex(e => new { e.MockId, e.ProfileId }, "nci_wi_Grades_A5C16EFA7F169E5542A86F864CDFD149");

            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.GradeNumber).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Classes");

            entity.ToTable("Lessons", "hub");

            entity.Property(e => e.DueDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Mock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Mocks");

            entity.HasIndex(e => e.CourseId, "IX_CourseId");

            entity.Property(e => e.Difficulty).HasDefaultValue(1);

            entity.HasOne(d => d.Course).WithMany(p => p.Mocks)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_dbo.Mocks_dbo.Courses_CourseId");
        });

        modelBuilder.Entity<MockQuestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.MockQuestions");

            entity.HasIndex(e => e.MockId, "IX_MockId");

            entity.HasIndex(e => e.QuestionId, "IX_QuestionId");

            entity.Property(e => e.BaseText).HasDefaultValue(false);

            entity.HasOne(d => d.Mock).WithMany(p => p.MockQuestions)
                .HasForeignKey(d => d.MockId)
                .HasConstraintName("FK_dbo.MockQuestions_dbo.Mocks_MockId");

            entity.HasOne(d => d.Question).WithMany(p => p.MockQuestions)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK_dbo.MockQuestions_dbo.Questions_QuestionId");
        });

        modelBuilder.Entity<MockResult>(entity =>
        {
            entity.HasIndex(e => new { e.ProfileId, e.MockId }, "nci_wi_MockResults_07EB1FAC74256E8D68C0DD95325CD6C8");

            entity.Property(e => e.Rsum).HasColumnName("RSum");

            entity.HasOne(d => d.Mock).WithMany(p => p.MockResults)
                .HasForeignKey(d => d.MockId)
                .HasConstraintName("FK_MockResults_Mocks");

            entity.HasOne(d => d.Profile).WithMany(p => p.MockResults)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("FK_MockResults_Profiles");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Packages");
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Parents");

            entity.HasIndex(e => e.ProfileId, "IX_ProfileId");

            entity.HasOne(d => d.Profile).WithMany(p => p.Parents)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("FK_dbo.Parents_dbo.Profiles_ProfileId");
        });

        modelBuilder.Entity<Performed>(entity =>
        {
            entity.ToTable("Performed", "hub");

            entity.HasIndex(e => new { e.ProfileId, e.ActivityId }, "nci_wi_Performed_EDFE4A7C513ED96F381558F5FDEFE5C7");

            entity.Property(e => e.Created).HasColumnType("datetime");

            entity.HasOne(d => d.Activity).WithMany(p => p.Performeds)
                .HasForeignKey(d => d.ActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Performed_Activity");

            entity.HasOne(d => d.Profile).WithMany(p => p.Performeds)
                .HasForeignKey(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Performed_Profiles");
        });

        modelBuilder.Entity<Period>(entity =>
        {
            entity.ToTable("Periods", "hub");

            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<Platform>(entity =>
        {
            entity.ToTable("Platform", "hub");

            entity.Property(e => e.Link).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<Proficiency>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Proficiency");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Profiles");
        });

        modelBuilder.Entity<ProfileActivity>(entity =>
        {
            entity.ToTable("ProfileActivities", "hub");

            entity.Property(e => e.Created).HasColumnType("datetime");

            entity.HasOne(d => d.Activity).WithMany(p => p.ProfileActivities)
                .HasForeignKey(d => d.ActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProfileActivities_Activity");

            entity.HasOne(d => d.Profile).WithMany(p => p.ProfileActivities)
                .HasForeignKey(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProfileActivities_Profiles");
        });

        modelBuilder.Entity<ProfilesSchoolsPackage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.ProfilesSchoolsPackages");

            entity.HasIndex(e => e.ProfileId, "IX_ProfileId");

            entity.HasOne(d => d.Profile).WithMany(p => p.ProfilesSchoolsPackages)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("FK_dbo.ProfilesSchoolsPackages_dbo.Profiles_ProfileId");

            entity.HasOne(d => d.SchoolsPackages).WithMany(p => p.ProfilesSchoolsPackages)
                .HasForeignKey(d => d.SchoolsPackagesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.ProfilesSchoolsPackages_dbo.SchoolsPackages_SchoolPackage_Id");
        });

        modelBuilder.Entity<Progress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Progress");

            entity.ToTable("Progress");

            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Modified).HasColumnType("datetime");

            entity.HasOne(d => d.CoursesPackages).WithMany(p => p.Progresses)
                .HasForeignKey(d => d.CoursesPackagesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Progress_dbo.CoursesPackages_CoursePackage_Id");

            entity.HasOne(d => d.CoursesSubjects).WithMany(p => p.Progresses)
                .HasForeignKey(d => d.CoursesSubjectsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Progress_dbo.CoursesSubjects_CourseSubject_Id");

            entity.HasOne(d => d.ProfileSchoolsPackage).WithMany(p => p.Progresses)
                .HasForeignKey(d => d.ProfileSchoolsPackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Progress_dbo.ProfilesSchoolsPackages_ProfileSchoolPackage_Id");

            entity.HasOne(d => d.QuestsSubjects).WithMany(p => p.Progresses)
                .HasForeignKey(d => d.QuestsSubjectsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Progress_dbo.QuestsSubjects_QuestSubject_Id");
        });

        modelBuilder.Entity<Quest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Quests");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Questions");

            entity.HasOne(d => d.Competency).WithMany(p => p.Questions)
                .HasForeignKey(d => d.CompetencyId)
                .HasConstraintName("FK_Questions_Competencies");
        });

        modelBuilder.Entity<QuestsQuestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.QuestsQuestions");

            entity.HasIndex(e => e.QuestId, "IX_QuestId");

            entity.HasIndex(e => e.QuestionId, "IX_QuestionId");

            entity.HasOne(d => d.Quest).WithMany(p => p.QuestsQuestions)
                .HasForeignKey(d => d.QuestId)
                .HasConstraintName("FK_dbo.QuestsQuestions_dbo.Quests_QuestId");

            entity.HasOne(d => d.Question).WithMany(p => p.QuestsQuestions)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK_dbo.QuestsQuestions_dbo.Questions_QuestionId");
        });

        modelBuilder.Entity<QuestsSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.QuestsSubjects");

            entity.HasIndex(e => e.QuestId, "IX_QuestId");

            entity.HasIndex(e => e.SubjectId, "IX_SubjectId");

            entity.HasOne(d => d.Quest).WithMany(p => p.QuestsSubjects)
                .HasForeignKey(d => d.QuestId)
                .HasConstraintName("FK_dbo.QuestsSubjects_dbo.Quests_QuestId");

            entity.HasOne(d => d.Subject).WithMany(p => p.QuestsSubjects)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK_dbo.QuestsSubjects_dbo.Subjects_SubjectId");
        });

        modelBuilder.Entity<Record>(entity =>
        {
            entity.ToTable("Records", "performance");

            entity.HasIndex(e => new { e.CourseId, e.PlatformId, e.ProfileId, e.ReferenceId, e.SchoolsPackagesId, e.Year }, "nci_wi_Records_B3533B8EC841C8385A7C038270D7097B");

            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.GradeNumber).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Course).WithMany(p => p.Records)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Records_Courses");

            entity.HasOne(d => d.Platform).WithMany(p => p.Records)
                .HasForeignKey(d => d.PlatformId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Records_Platform");

            entity.HasOne(d => d.Profile).WithMany(p => p.Records)
                .HasForeignKey(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Records_Profiles");

            entity.HasOne(d => d.SchoolsPackages).WithMany(p => p.Records)
                .HasForeignKey(d => d.SchoolsPackagesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Records_SchoolsPackages");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Calendar");

            entity.ToTable("Schedule", "hub");

            entity.HasOne(d => d.Package).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calendar_Packages");

            entity.HasOne(d => d.Period).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.PeriodId)
                .HasConstraintName("FK_Schedule_Periods");
        });

        modelBuilder.Entity<School>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Schools");

            entity.Property(e => e.ArvorePartnerId).HasColumnName("arvore_partner_id");
            entity.Property(e => e.ArvoreReferenceId).HasColumnName("arvore_reference_id");
            entity.Property(e => e.DefaultCalendar).HasColumnName("default_calendar");
            entity.Property(e => e.EduQuestPartnerId).HasColumnName("edu_quest_partner_id");
            entity.Property(e => e.EduQuestPath).HasColumnName("edu_quest_path");
        });

        modelBuilder.Entity<SchoolsPackage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.SchoolsPackages");

            entity.HasIndex(e => e.PackageId, "IX_PackageId");

            entity.HasIndex(e => e.SchoolId, "IX_SchoolId");

            entity.Property(e => e.ArvorePartnerId).HasColumnName("arvore_partner_id");
            entity.Property(e => e.ArvoreReferenceId).HasColumnName("arvore_reference_id");

            entity.HasOne(d => d.Package).WithMany(p => p.SchoolsPackages)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK_dbo.SchoolsPackages_dbo.Packages_PackageId");

            entity.HasOne(d => d.School).WithMany(p => p.SchoolsPackages)
                .HasForeignKey(d => d.SchoolId)
                .HasConstraintName("FK_dbo.SchoolsPackages_dbo.Schools_SchoolId");
        });

        modelBuilder.Entity<SchoolsPackagesLesson>(entity =>
        {
            entity.ToTable("SchoolsPackagesLessons", "hub");

            entity.HasOne(d => d.Lesson).WithMany(p => p.SchoolsPackagesLessons)
                .HasForeignKey(d => d.LessonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SchoolsPackagesLessons_Lessons");

            entity.HasOne(d => d.SchoolsPackages).WithMany(p => p.SchoolsPackagesLessons)
                .HasForeignKey(d => d.SchoolsPackagesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SchoolsPackagesLessons_SchoolsPackages");
        });

        modelBuilder.Entity<SchoolsPlatform>(entity =>
        {
            entity.ToTable("SchoolsPlatforms", "hub");

            entity.HasOne(d => d.Platform).WithMany(p => p.SchoolsPlatforms)
                .HasForeignKey(d => d.PlatformId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SchoolsPlatforms_Platform");

            entity.HasOne(d => d.School).WithMany(p => p.SchoolsPlatforms)
                .HasForeignKey(d => d.SchoolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SchoolsPlatforms_Schools");
        });

        modelBuilder.Entity<SchoolsStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.SchoolsStudents");

            entity.HasIndex(e => e.ProfileId, "IX_ProfileId");

            entity.HasIndex(e => e.SchoolId, "IX_SchoolId");

            entity.HasOne(d => d.Profile).WithMany(p => p.SchoolsStudents)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("FK_dbo.SchoolsStudents_dbo.Profiles_ProfileId");

            entity.HasOne(d => d.School).WithMany(p => p.SchoolsStudents)
                .HasForeignKey(d => d.SchoolId)
                .HasConstraintName("FK_dbo.SchoolsStudents_dbo.Schools_SchoolId");
        });

        modelBuilder.Entity<Strip>(entity =>
        {
            entity.Property(e => e.StripBegin).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.StripEnd).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Subjects");
        });

        modelBuilder.Entity<Veritable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Veritables");

            entity.HasIndex(e => e.AnswerId, "IX_Answer_Id");

            entity.HasIndex(e => e.QuestionId, "IX_QuestionId");

            entity.HasOne(d => d.Answer).WithMany(p => p.Veritables)
                .HasForeignKey(d => d.AnswerId)
                .HasConstraintName("FK_dbo.Veritables_dbo.Answers_Answer_Id");
        });

        modelBuilder.Entity<ViewDocumentosFeito>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewDocumentosFeitos");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.ProfileId).HasColumnName("Profile_Id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
