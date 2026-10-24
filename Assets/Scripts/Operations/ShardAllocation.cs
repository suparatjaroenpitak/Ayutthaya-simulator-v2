using System.Threading.Tasks;

namespace AyutthayaSimulator.Operations
{
    public sealed class ShardAssignment { public string shardId; public string zoneId; public string endpoint; public bool accepted; }
    public interface IShardAllocator { Task<ShardAssignment> AllocateAsync(string accountId, string zoneId); Task<bool> ReleaseAsync(string shardId); }
    public interface ILoadBalancerRegistration { Task<bool> RegisterAsync(string instanceId, string endpoint, int capacity); Task<bool> DrainAsync(string instanceId); }
    public sealed class ShardRoutingClient
    {
        private readonly IShardAllocator allocator;
        public ShardRoutingClient(IShardAllocator value) { allocator = value; }
        public Task<ShardAssignment> RequestZoneAsync(string accountId, string zoneId) => allocator.AllocateAsync(accountId, zoneId);
    }
}
