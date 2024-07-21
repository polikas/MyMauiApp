
namespace MyMauiApp
{
    public partial class TestPage : ContentPage
    {
        int count = 0;

        Label counterLabel;

        public TestPage()
        {
            var myScrollView = new ScrollView();

            var myStackLayout = new VerticalStackLayout
            {
                BackgroundColor = Color.FromRgba("7B3F00")
            };
            myScrollView.Content = myStackLayout;

            counterLabel = new Label
            {
                Text = "Test Page Current count: 0",
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };
            myStackLayout.Children.Add(counterLabel);

            var myButton = new Button
            {
                Text = "Click me",
                HorizontalOptions = LayoutOptions.Center
            };
            myStackLayout.Children.Add(myButton);

            myButton.Clicked += OnCounterClicked!;

            this.Content = myScrollView;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;
            counterLabel.Text = $"Test Page Current count: {count}";

            SemanticScreenReader.Announce(counterLabel.Text);
        }
    }
}
