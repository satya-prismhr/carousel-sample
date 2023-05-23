using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace MAUICarousel;

public partial class MainPage : ContentPage
{
    private ItemViewModel ItemViewModelData
    {
        get
        {
            return BindingContext as ItemViewModel;
        }
    }
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new ItemViewModel();
        ItemViewModelData.UpdateCarouselview = UpdateData;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ItemViewModelData.LoadData();
    }

    private void UpdateData(int obj)
    {
        carouselview.CurrentItem = ItemViewModelData.Items[obj];
        carouselview.Position = obj;
    }
}
public class ItemModel
{
    public string Name { get; set; }
    public string Location { get; set; }
}

public class ItemViewModel : BindableObject
{
    public Action<int> UpdateCarouselview { get; set; }
    public ItemViewModel()
    {

    }


    public void LoadData()
    {
        Items.Clear();
        for (int i = 1; i < 10; i++)
        {
            Items.Add(new ItemModel { Name = "Monkey " + i, Location = "Location" + i });
        }
        UpdateCarouselview?.Invoke(2);
    }

    private ObservableCollection<ItemModel> _items = new ObservableCollection<ItemModel>();
    public ObservableCollection<ItemModel> Items
    {
        get { return _items; }
        set
        {
            _items = value;
            OnPropertyChanged(nameof(Items));
        }
    }
}

