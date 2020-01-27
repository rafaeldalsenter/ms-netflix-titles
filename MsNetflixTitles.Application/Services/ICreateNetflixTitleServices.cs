using MsNetflixTitles.CrossCutting.Dtos;
using System.Threading.Tasks;

namespace MsNetflixTitles.Application.Services
{
    public interface ICreateNetflixTitleServices
    {
        Task<NetflixTitleDto> Create(NetflixTitleDto dto);
    }
}