using StackExchange.Redis;

using System.Text.Json;

namespace Redis;

public class CacheService : ICacheService
{
     private  IDatabase _cacheDb;

    public CacheService(IDatabase cacheDb)
    {
        var redis = ConnectionMultiplexer.Connect("localhost:6379");
        _cacheDb = redis.GetDatabase();
    }


    public T GetData<T>(string key)
    {
        var value = _cacheDb.StringGet(key);

        if(value.HasValue)
        {
            return JsonSerializer.Deserialize<T>(value);
        }

        return default;
    }

    public object RemoveData(string key)
    {
        var _exist = _cacheDb.KeyExists(key);

        if(_exist)
        {
            return _cacheDb.KeyDelete(key);
        }

        return false;

    }

    public bool SetData<T>(string key, T data, DateTimeOffset expirationTime)
    {
        var expire = expirationTime.DateTime.Subtract(DateTime.Now);

        return  _cacheDb.StringSet(key, JsonSerializer.Serialize(data), expire);

    }
}
