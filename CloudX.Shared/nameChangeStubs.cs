using SkyFrost.Base;
namespace CloudX.Shared
{
    public enum NeosDB_Endpoint
    {
        Default = DB_Endpoint.Default,
        Video = DB_Endpoint.Video
    }
    public class CloudXInterface : SkyFrostInterface
    {
        public CloudXInterface(string uid, SkyFrostConfig config) : base(uid, config)
        {
        }
    }
    public class Friend : Contact { }
    public class FriendManager : ContactManager
    {
        public FriendManager(SkyFrostInterface cloud, string contactPath) : base(cloud, contactPath)
        {
        }
    }
    public enum FriendStatus
    {
        None = ContactStatus.None,
        SearchResult = ContactStatus.SearchResult,
        Requested = ContactStatus.Requested,
        Ignored = ContactStatus.Ignored,
        Blocked = ContactStatus.Blocked,
        Accepted = ContactStatus.Accepted
    }
    public interface INeosHubClient : IHubClient { }
    public interface INeosHubDebugClient : IHubDebugClient { }
    public interface INeosHubMessagingClient : IHubMessagingClient { }
    public interface INeosModerationClient : IModerationClient { }
    public interface INeosHubServer : IHubServer { }
    public class NeosHub : AppHub
    {
        public NeosHub(Microsoft.AspNetCore.SignalR.Client.HubConnection hub) : base(hub)
        {
        }
    }
    public class NeosBuildConfiguration : AppBuildConfiguration { }
    public abstract class BuildVariantBase : BuildVariantDescriptor { }
    public enum NeosBuildType
    {
        Unity_Mono = BuildType.Unity_Mono,
        Unity_Mono_Debug = BuildType.Unity_Mono_Debug,
        Unity_IL2CPP_Release = BuildType.Unity_IL2CPP_Release,
        Unity_IL2CPP_Master = BuildType.Unity_IL2CPP_Master,
        HeadlessNetFramework = BuildType.HeadlessNetFramework,
        HeadlessNet = BuildType.HeadlessNet,
        UnitySDK = BuildType.UnitySDK,
    }
    public class NeosBuildVariant : AppBuildVariantDescriptor { }
    public class NeosConfig : AppConfig { }
    public class NeosDBAsset : DBAsset { }
    public class OnlineUserStats : OnlineStats { }
    public class PatreonSnapshot : LegacyPatreonSnapshot { }
    public class UserPatreonData : LegacyUserPatreonData { }
}
