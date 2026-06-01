namespace ContextCompiler.Skills.Abstractions;

public sealed class SkillLockFile
{
    public int FormatVersion { get; set; } = 1;
    public DateTime GeneratedAt { get; set; } = DateTime.UnixEpoch;
    public List<LockedSkill> Skills { get; set; } = [];

    public sealed class LockedSkill
    {
        public string Id { get; set; } = default!;
        public string Provider { get; set; } = default!;
        public string RequestedVersion { get; set; } = default!;
        public string ResolvedVersion { get; set; } = default!;
        public string SourceUri { get; set; } = default!;
        public string Checksum { get; set; } = default!;
        public string CachePath { get; set; } = default!;
        public List<string> RequestedBy { get; set; } = [];
        public List<string> Files { get; set; } = [];
    }
}
