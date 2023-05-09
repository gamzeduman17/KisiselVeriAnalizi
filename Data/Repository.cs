using VeriAnalizi.Models;

namespace VeriAnalizi.Data
{
    public class Repository
    {
        public static IReadOnlyList<CheckboxViewModel> SorulariGetir()
        {
            return new List<CheckboxViewModel>
            {
                new CheckboxViewModel
                {
                     Id = 1,
            LabelName = "Bugün ne kadar spor yaptın?",
            IsChecked = true
        },
        new CheckboxViewModel
        {
            Id = 2,
            LabelName = "Hiç",
            IsChecked = false
        },
        new CheckboxViewModel
        {
            Id = 3,
            LabelName = "1 saat",
            IsChecked = true
        },
        new CheckboxViewModel
        {
            Id = 4,
            LabelName = "2 saat+",
            IsChecked = false
                }
            };
        }
    }
}
