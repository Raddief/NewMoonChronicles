using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class EntityManager
{
    private Dictionary<string, EntityStats> _entities = new Dictionary<string, EntityStats>();

    public void AddEntity(string id, EntityStats entity)
    {
        if (!_entities.ContainsKey(id))
        {
            _entities[id] = entity;
        }
    }

    public EntityStats GetEntity(string id)
    {
        if (_entities.ContainsKey(id))
        {
            return _entities[id];
        }
        throw new KeyNotFoundException($"Entity with id '{id}' not found.");
    }

    public void GainExperience(string id, int xp)
    {
        if (_entities.ContainsKey(id))
        {
            _entities[id].GainExperience(xp);
        }
    }

    public void SaveEntities(string filePath)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(_entities, options);
        File.WriteAllText(filePath, json);
    }

    public void LoadEntities(string filePath)
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            var deserializedEntities = JsonSerializer.Deserialize<Dictionary<string, EntityStats>>(json);
            if (deserializedEntities != null)
            {
                _entities = deserializedEntities;
            }
        }
    }

    public void PrintEntityStats(string id)
    {
        if (_entities.ContainsKey(id))
        {
            var entity = _entities[id];
            System.Console.WriteLine($"Name: {entity.Name}, Level: {entity.Level}, HP: {entity.HealthPoint}, AP: {entity.AttackPower}, DP: {entity.DefensePoint}, Agility: {entity.Agility}, XP: {entity.Experience}");
        }
    }
}