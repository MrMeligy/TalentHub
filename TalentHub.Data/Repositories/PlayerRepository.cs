using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Business.Abstraction;
using static TalentHub.Business.Dtos.PlayerDto;
using TalentHub.Core.Entities;

namespace TalentHub.Data.Repositories
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        private readonly ApplicationDbContext _ctx;

        public PlayerRepository(ApplicationDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<IReadOnlyList<PlayerReadDto>> GetAllPlayersAsync(int skip, int pageSize)
        {
            return await _ctx.Players
                .AsNoTracking()
                .Select(p => new PlayerReadDto
                {
                    Id = p.Id,
                    AcademyTeamId = p.AcademyTeamId,
                    Name = p.Name,
                    Image = p.Image,
                    TeamName = p.AcademyTeam.Academy.Name,
                    AcademyImage = p.AcademyTeam.Academy.Image,
                    FavouriteFoot = p.FavouriteFoot,
                    Position = p.Position,
                    Height = p.Height,
                    Weight = p.Weight,
                    Rating = p.Rating,
                    Nationality = p.Nationality,
                    ShirtNumber = p.ShirtNumber,
                    TotalGoals = p.TotalGoals,
                    TotalAssists = p.TotalAssists,
                    TotalSaves = p.TotalSaves,
                    DOB = p.DOB,
                    TotalTackles = p.TotalTackles,
                    SuccessTackles = p.SuccessTackles,
                    TotalInterceptions = p.TotalInterceptions,
                    TotalMatches = p.TotalMatches,
                    TotalMinutes = p.TotalMinutes,


                })
                .OrderByDescending(p => p.Rating)
                .ThenBy(p=>p.Id)
                .Skip(skip).Take(pageSize)
                .ToListAsync();
        }

        public async Task<PlayerReadDto?> GetPlayerByIdAsync(Guid playerId)
        {
            return await _ctx.Players
                .Select(p => new PlayerReadDto
                {
                    Id = p.Id,
                    AcademyTeamId = p.AcademyTeamId,
                    Name = p.Name,
                    Image = p.Image,
                    TeamName = p.AcademyTeam.Academy.Name,
                    AcademyImage = p.AcademyTeam.Academy.Image,
                    FavouriteFoot = p.FavouriteFoot,
                    Position = p.Position,
                    Height = p.Height,
                    Weight = p.Weight,
                    Rating = p.Rating,
                    Nationality = p.Nationality,
                    ShirtNumber = p.ShirtNumber,
                    TotalGoals = p.TotalGoals,
                    TotalAssists = p.TotalAssists,
                    TotalSaves = p.TotalSaves,
                    DOB = p.DOB,
                    TotalTackles = p.TotalTackles,
                    SuccessTackles = p.SuccessTackles,
                    TotalInterceptions = p.TotalInterceptions,
                    TotalMatches = p.TotalMatches,
                    TotalMinutes = p.TotalMinutes,


                })
                .FirstOrDefaultAsync(p => p.Id == playerId);
        }

        public async Task<IReadOnlyList<PlayerReadDto>> GetPlayersByAcademyAsync(Guid academyId, int skip, int pageSize)
        {
            return await _ctx.Players
                .AsNoTracking()
                .Where(p => p.AcademyTeam.Academy.Id == academyId)
                .Select(p => new PlayerReadDto
                {
                    Id = p.Id,
                    AcademyTeamId = p.AcademyTeamId,
                    Name = p.Name,
                    Image = p.Image,
                    TeamName = p.AcademyTeam.AgeGroup,
                    AcademyImage = p.AcademyTeam.Academy.Image,
                    FavouriteFoot = p.FavouriteFoot,
                    Position = p.Position,
                    Height = p.Height,
                    Weight = p.Weight,
                    Rating = p.Rating,
                    Nationality = p.Nationality,
                    ShirtNumber = p.ShirtNumber,
                    TotalGoals = p.TotalGoals,
                    TotalAssists = p.TotalAssists,
                    TotalSaves = p.TotalSaves,
                    DOB = p.DOB,
                    TotalTackles = p.TotalTackles,
                    SuccessTackles = p.SuccessTackles,
                    TotalInterceptions = p.TotalInterceptions,
                    TotalMatches = p.TotalMatches,
                    TotalMinutes = p.TotalMinutes,
                })
                .OrderByDescending(p => p.TeamName)
                .ThenBy(p => p.Rating)
                .ThenBy(p => p.Id)
                .Skip(skip).Take(pageSize)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<PlayerReadDto>> GetPlayersByMatchAsync(Guid matchId)
        {
            return await _ctx.PlayerMatches
                .AsNoTracking()
                .Where(m=>m.MatchId==matchId)
                .Select(p=>new PlayerReadDto
                {
                    Id = p.PlayerId,
                    AcademyTeamId = p.Player.AcademyTeamId,
                    Name = p.Player.Name,
                    Image = p.Player.Image,
                    TeamName = p.Player.AcademyTeam.Academy.Name,
                    AcademyImage = p.Player.AcademyTeam.Academy.Image,
                    FavouriteFoot = p.Player.FavouriteFoot,
                    Position = p.Player.Position,
                    Height = p.Player.Height,
                    Weight = p.Player.Weight,
                    Rating = p.Rating,
                    Nationality = p.Player.Nationality,
                    ShirtNumber = p.Player.ShirtNumber,
                    TotalGoals = p.Goals,
                    TotalAssists = p.Assists,
                    TotalSaves = p.Saves,
                    DOB = p.Player.DOB,
                    TotalTackles = p.Tackles,
                    SuccessTackles = p.SuccessTackles,
                    TotalInterceptions = p.Interceptions,
                    TotalMatches = null,
                    TotalMinutes = p.Minutes,
                })
                .OrderByDescending(p=>p.Rating)
                .ThenBy(p=>p.Id)
                .ToListAsync();            
        }

        public async Task<IReadOnlyList<PlayerReadDto>> GetPlayersByTeamAsync(Guid teamId)
        {
            return await _ctx.Players
                .AsNoTracking()
                .Where(p => p.AcademyTeamId == teamId)
                .Select(p => new PlayerReadDto
                {
                    Id = p.Id,
                    AcademyTeamId = p.AcademyTeamId,
                    Name = p.Name,
                    Image = p.Image,
                    TeamName = p.AcademyTeam.Academy.Name,
                    AcademyImage = p.AcademyTeam.Academy.Image,
                    FavouriteFoot = p.FavouriteFoot,
                    Position = p.Position,
                    Height = p.Height,
                    Weight = p.Weight,
                    Rating = p.Rating,
                    Nationality = p.Nationality,
                    ShirtNumber = p.ShirtNumber,
                    TotalGoals = p.TotalGoals,
                    TotalAssists = p.TotalAssists,
                    TotalSaves = p.TotalSaves,
                    DOB = p.DOB,
                    TotalTackles = p.TotalTackles,
                    SuccessTackles = p.SuccessTackles,
                    TotalInterceptions = p.TotalInterceptions,
                    TotalMatches = p.TotalMatches,
                    TotalMinutes = p.TotalMinutes,
                })
                .OrderByDescending(p => p.Rating)
                .ThenBy(p => p.Id)
                .ToListAsync();
        }
    }
}
