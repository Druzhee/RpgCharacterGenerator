using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RpgCharacterGenerator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    List<Player> _allCharacters = new();

    int _currentId = 1;

    List<string> classes = new()
    {
        "Fighter",
        "Wizard"
    };

    public MainWindow()
    {
        InitializeComponent();

        // Lägg i våra classes-strängar i ComboBoxen

        cbSelectRole.ItemsSource = classes;
    }

    private void cbSelectRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Kolla om vi har selectat Fighter eller Wizard
        string selectedRole = (string)cbSelectRole.SelectedItem;

        // Byt content i labeln för speciell stat till rätt namn
        if (selectedRole == "Fighter")
        {
            lblStats.Content = "Armor";
        }
        else if (selectedRole == "Wizard")
        {
            lblStats.Content = "Mana";
        }

        // Visa labeln för speciell stat och dess inputruta
        lblStats.Visibility = Visibility.Visible;
        txtStats.Visibility = Visibility.Visible;
    }

    private void btnRoleStats_Click(object sender, RoutedEventArgs e)
    {
        // Autogenerera strength
        // Sätt strength

        txtStr.Text = GenerateStat().ToString();

        // Autogenerera intelligence
        // Sätt intelligence

        txtInt.Text = GenerateStat().ToString();
    }

    private int GenerateStat()
    {
        return new Random().Next(3, 19);
    }

    private bool ValidateStringConversion(string stringToValidate)
    {
        bool validateOk = int.TryParse(stringToValidate, out int result);

        return validateOk;
    }

    private void btnSaveCharacter_Click(object sender, RoutedEventArgs e)
    {
        string strength = txtStr.Text;
        string intelligence = txtInt.Text;
        string name = txtName.Text;
        string stat = txtStats.Text;
        string role = (string)cbSelectRole.SelectedItem;

        if (strength != "" && intelligence != "" && name != "" && stat != "" && role != "" && ValidateStringConversion(stat))
        {
            // Lägg till karaktären i listan med alla kolumner

            lstCharacter.Items.Add(new
            {
                Id = _currentId,
                Name = name,
                Strength = strength,
                Intelligence = intelligence,
                Role = role,
                Ability = stat
            });

            // Lägg till karaktären i "databasen"

            if (role == "Fighter")
            {
                // Gör en ny fighter
                Fighter newFighter = new(_currentId, name, int.Parse(strength), int.Parse(intelligence), int.Parse(stat));

                _allCharacters.Add(newFighter);
            }
            else if (role == "Wizard")
            {
                // Gör en ny wizard

                Wizard newWizard = new(_currentId, name, int.Parse(strength), int.Parse(intelligence), int.Parse(stat));

                _allCharacters.Add(newWizard);
            }

            _currentId++;
        }
        else
        {
            // Visa varning!

            MessageBox.Show("Please add all the required information in the correct format!", "Warning");
        }
    }
}
