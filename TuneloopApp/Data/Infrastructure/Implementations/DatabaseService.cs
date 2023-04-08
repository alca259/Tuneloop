using SQLite;
using System.Diagnostics;
using Tuneloop.Data.Models;

namespace Tuneloop.Data.Infrastructure.Implementations;

public sealed class DatabaseService : IDatabaseService
{
    private SQLiteAsyncConnection _connection;
    private bool _initialized = false;

    public DatabaseService()
    {
        _connection = new SQLiteAsyncConnection(AppConstants.Database.FullPath, AppConstants.Database.OPEN_FLAGS);

        // Debug purposes
        _connection.Tracer = new Action<string>(q => Debug.WriteLine(q));
        _connection.Trace = true;
    }

    public async Task<int> CountItemsWithQuery(string query)
    {
        await Init();
        return await _connection.ExecuteScalarAsync<int>(query);
    }

    public async Task<bool> ExecuteQuery(string query)
    {
        await Init();
        var op = await _connection.ExecuteAsync(query);
        return op > 0;
    }

    public async Task<List<T>> GetItemsWithQuery<T>(string query) where T : BaseEntity, new()
    {
        await Init();
        return await _connection.QueryAsync<T>(query);
    }

    public async Task<List<T>> ListAll<T>() where T : BaseEntity, new()
    {
        await Init();
        return await _connection.Table<T>().ToListAsync();
    }

    public async Task<int> CreateOrReplace<T>(T entity) where T : BaseEntity, new()
    {
        await Init();
        return await _connection.InsertOrReplaceAsync(entity, typeof(T));
    }

    public async Task<int> CreateList<T>(IEnumerable<T> entities) where T : BaseEntity, new()
    {
        await Init();
        return await _connection.InsertAllAsync(entities, typeof(T));
    }

    public async Task<int> Delete<T>(T entity) where T : BaseEntity, new()
    {
        await Init();
        return await _connection.DeleteAsync(entity);
    }

    public async Task<int> DeleteAll<T>() where T : BaseEntity, new()
    {
        await Init();
        var mapping = await _connection.GetMappingAsync(typeof(T), AppConstants.Database.CREATE_FLAGS);
        return await _connection.DeleteAllAsync(mapping);
    }

    private async Task Init()
    {
        if (_initialized) return;

        try
        {
            _initialized = true;

            await CreateTables();
            var count = await CountItems();

            if (count == 0)
            {
                await AddInitialData();
            }
        }
        catch (Exception)
        {
            _initialized = false;
            throw;
        }
    }

    private async Task CreateTables()
    {
        var types = new[]
        {
            typeof(EqualizerEntity),
            typeof(EqualizerGroupEntity),
            typeof(LastPlayedEntity),
            typeof(LibraryFolderEntity),
            typeof(PlaylistEntity),
            typeof(RelEqualizerGroupEntity),
            typeof(RelPlaylistSongEntity),
            typeof(SongEntity),
            typeof(SongStatsEntity)
        };

        await _connection.CreateTablesAsync(AppConstants.Database.CREATE_FLAGS, types);
    }

    private async Task<int> CountItems()
    {
        var tables = new[]
        {
            AppConstants.Tables.EQUALIZER,
            AppConstants.Tables.EQUALIZER_GROUP
        };
        var count = 0;

        foreach (var table in tables)
        {
            var countQuery = $"SELECT COUNT(*) FROM {table}";
            var tableCount = await CountItemsWithQuery(countQuery);
            Debug.WriteLine($"{table}: {tableCount}");
            count += tableCount;
        }

        return count;
    }

    private async Task AddInitialData()
    {
        var eq = new EqualizerEntity();
        await CreateOrReplace(eq);

        var lowest = new EqualizerGroupEntity { Code = AppConstants.EqualizerGroupCodes.LOWEST, MinRange = 20, MaxRange = 80, Value = 60, Volume = 0 };
        var low = new EqualizerGroupEntity { Code = AppConstants.EqualizerGroupCodes.LOW, MinRange = 80, MaxRange = 250, Value = 230, Volume = 0 };
        var middle = new EqualizerGroupEntity { Code = AppConstants.EqualizerGroupCodes.MIDDLE, MinRange = 250, MaxRange = 1200, Value = 910, Volume = 0 };
        var middleHigh = new EqualizerGroupEntity { Code = AppConstants.EqualizerGroupCodes.MIDDLE_HIGH, MinRange = 1200, MaxRange = 5000, Value = 4000, Volume = 0 };
        var highest = new EqualizerGroupEntity { Code = AppConstants.EqualizerGroupCodes.HIGH, MinRange = 5000, MaxRange = 20000, Value = 14000, Volume = 0 };
        await CreateOrReplace(lowest);
        await CreateOrReplace(low);
        await CreateOrReplace(middle);
        await CreateOrReplace(middleHigh);
        await CreateOrReplace(highest);

        await CreateOrReplace(new RelEqualizerGroupEntity { EqualizerId = eq.Id, EqualizerGroupId = lowest.Id });
        await CreateOrReplace(new RelEqualizerGroupEntity { EqualizerId = eq.Id, EqualizerGroupId = low.Id });
        await CreateOrReplace(new RelEqualizerGroupEntity { EqualizerId = eq.Id, EqualizerGroupId = middle.Id });
        await CreateOrReplace(new RelEqualizerGroupEntity { EqualizerId = eq.Id, EqualizerGroupId = middleHigh.Id });
        await CreateOrReplace(new RelEqualizerGroupEntity { EqualizerId = eq.Id, EqualizerGroupId = highest.Id });
    }
}

