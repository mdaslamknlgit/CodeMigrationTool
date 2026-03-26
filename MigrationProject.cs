using System;
using System.Collections.Generic;

namespace CodeMigrationTool.Models
{
    public class MigrationProject
    {
        public int Id { get; set; }
        
        public string ProjectName { get; set; } = string.Empty;
        
        public string SourcePath { get; set; } = string.Empty;
        
        public string TargetPath { get; set; } = string.Empty;
        
        public string Status { get; set; } = "Pending"; // Analyzing, Transforming, Completed, Failed
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? CompletedAt { get; set; }
        
        public int TotalFiles { get; set; }
        
        public int TransformedFiles { get; set; }
        
        public string? ErrorMessage { get; set; }
        
        // Navigation
        public virtual ICollection<MigrationLog> Logs { get; set; } = new List<MigrationLog>();
    }
    
    public class MigrationLog
    {
        public int Id { get; set; }
        
        public int ProjectId { get; set; }
        
        public string Message { get; set; } = string.Empty;
        
        public string Level { get; set; } = "Info"; // Info, Warning, Error
        
        public string? SourceFile { get; set; }
        
        public int? LineNumber { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation
        public virtual MigrationProject Project { get; set; } = null!;
    }
    
    public class TransformationRule
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        public string SourcePattern { get; set; } = string.Empty;
        
        public string TargetPattern { get; set; } = string.Empty;
        
        public string RuleType { get; set; } = "Namespace"; // Namespace, Package, Syntax, API
        
        public int Priority { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}