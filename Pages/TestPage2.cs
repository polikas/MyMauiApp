namespace MyMauiApp
{
    public partial class TestPage2 : ContentPage
    {

        string? translatedNumber;

        Label enterPhoneWordLabel;
        Entry phoneNumberText;
        Button translateBtn;
        Button callBtn;

        public TestPage2()
        {
            //InitializeComponent();

            var myScrollView = new ScrollView();

            var myStackLayout = new VerticalStackLayout
            {
                Padding = 20,
                Spacing = 15
            };
            myScrollView.Content = myStackLayout;

            enterPhoneWordLabel = new Label
            {
                FontSize = 20,
                Text = "Test Page 2 Enter a Phoneword"
            };
            myStackLayout.Children.Add(enterPhoneWordLabel);

            phoneNumberText = new Entry
            {
                Text = "1-555-NETMAUI"
            };
            myStackLayout.Children.Add(phoneNumberText);

            translateBtn = new Button
            {
                Text = "Translate"
            };
            myStackLayout.Children.Add(translateBtn);
            translateBtn.Clicked += OnTranslate!;


            callBtn = new Button
            {
                IsEnabled = false,
                Text = "Call"
            };
            myStackLayout.Children.Add(callBtn);
            callBtn.Clicked += OnCall!;

            this.Content = myScrollView;
        }

        private void OnTranslate(object sender, EventArgs e)
        {
            string enteredNumber = phoneNumberText.Text;
            translatedNumber = MyMauiApp.PhonewordTranslator.ToNumber(enteredNumber);

            if (!string.IsNullOrEmpty(translatedNumber))
            {
                callBtn.IsEnabled = true;
                callBtn.Text = "Call " + translatedNumber;
            }
            else
            {
                callBtn.IsEnabled = false;
                callBtn.Text = "Call";
            }
        }

        async void OnCall(object sender, EventArgs e)
        {
            if (await this.DisplayAlert(
                "Dial a Number",
                "Would you like to call " + translatedNumber + "?",
                "Yes",
                "No"))
            {
                try
                {
                    if (PhoneDialer.Default.IsSupported)
                    {
                        PhoneDialer.Default.Open(translatedNumber!);
                    }
                }
                catch (ArgumentNullException)
                {
                    await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
                }
                catch (Exception)
                {
                    await DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
                }
            }
        }
    }

}
