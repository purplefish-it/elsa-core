﻿using System.Collections.Generic;
using Elsa.Client.Comparers;
using NodaTime;

namespace Elsa.Client.Models
{
    public class WorkflowInstance
    {
        private HashSet<BlockingActivity> _blockingActivities = new HashSet<BlockingActivity>(BlockingActivityEqualityComparer.Instance);
        
        public WorkflowInstance()
        {
            Variables = new Variables();
            Activities = new System.Collections.Generic.List<ActivityInstance>();
            ExecutionLog = new System.Collections.Generic.List<ExecutionLogEntry>();
            ScheduledActivities = new Stack<ScheduledActivity>();
            PostScheduledActivities = new Stack<ScheduledActivity>();
        }

        public int Id { get; set; }
        public string WorkflowInstanceId { get; set; } = default!;
        public string WorkflowDefinitionId { get; set; } = default!;
        public int Version { get; set; }
        public WorkflowStatus Status { get; set; }
        public string? CorrelationId { get; set; }
        public string? ContextId { get; set; }
        public Instant CreatedAt { get; set; }
        public Variables Variables { get; set; }
        public object? Output { get; set; }
        public ICollection<ActivityInstance> Activities { get; set; }

        public HashSet<BlockingActivity> BlockingActivities
        {
            get => _blockingActivities;
            set => _blockingActivities = new HashSet<BlockingActivity>(value, BlockingActivityEqualityComparer.Instance);
        }
        
        public ICollection<ExecutionLogEntry> ExecutionLog { get; set; }
        public WorkflowFault? Fault { get; set; }
        public Stack<ScheduledActivity> ScheduledActivities { get; set; }
        public Stack<ScheduledActivity> PostScheduledActivities { get; set; }
    }
}