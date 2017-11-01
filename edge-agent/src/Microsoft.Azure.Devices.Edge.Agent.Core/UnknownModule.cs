// Copyright (c) Microsoft. All rights reserved.

namespace Microsoft.Azure.Devices.Edge.Agent.Core
{
    using Newtonsoft.Json;

    public class UnknownModule : IModule
    {
        public virtual string Type => "Unknown";

        public virtual string Name { get => "Unknown"; set { } }

        public virtual string Version => string.Empty;

        public virtual ModuleStatus DesiredStatus => ModuleStatus.Unknown;

        public virtual RestartPolicy RestartPolicy => RestartPolicy.Never;

        public virtual ConfigurationInfo ConfigurationInfo => new ConfigurationInfo();

        public bool Equals(IModule other) => other != null && object.ReferenceEquals(this, other);
    }

    public class UnknownEdgeHubModule : UnknownModule, IEdgeHubModule
    {
        UnknownEdgeHubModule() { }

        public static UnknownEdgeHubModule Instance { get; } = new UnknownEdgeHubModule();

        [JsonIgnore]
        public override string Version => string.Empty;
    }

    public class UnknownEdgeAgentModule : UnknownModule, IEdgeAgentModule
    {
        UnknownEdgeAgentModule() { }

        public static UnknownEdgeAgentModule Instance { get; } = new UnknownEdgeAgentModule();

        [JsonIgnore]
        public override string Version => string.Empty;

        [JsonIgnore]
        public override RestartPolicy RestartPolicy => RestartPolicy.Never;

        [JsonIgnore]
        public override ModuleStatus DesiredStatus => ModuleStatus.Unknown;
    }
}