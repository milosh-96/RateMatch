using Microsoft.AspNetCore.Mvc.Rendering;
using RateMatch.Mvc.Data;

namespace RateMatch.Mvc.Models.SportsMatches
{
    public class SportsMatchCreateViewModel
    {
        public IEnumerable<SelectListItem> Sports { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Competitions { get; set; } = new List<SelectListItem>();
        public SportsMatchDto ItemDto { get; set; } = new SportsMatchDto();

    }
}
