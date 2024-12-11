using BandApp.Models;
using BandApp.Utils;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;

namespace BandApp
{
    public partial class MainWindow : Window
    {
        private readonly BandFacade _facade = new BandFacade();

        public MainWindow()
        {
            InitializeComponent();

            var observer = new BandObserver();
            BandDataManager.Instance.RegisterObserver(observer);

            MainDataGrid.ItemsSource = _facade.GetMembers();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog { Filter = "XML Files|*.xml" };
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    var members = XmlHandler.LoadFromFile(openFileDialog.FileName);
                    if (members.Any())
                    {
                        BandDataManager.Instance.ClearMembers();
                        foreach (var member in members)
                        {
                            BandDataManager.Instance.AddMember(member);
                        }

                        MainDataGrid.ItemsSource = _facade.GetMembers();
                        MessageBox.Show("Members loaded successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("No members were loaded from the file.", "Load Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading file: {ex.Message}", "Load Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog { Filter = "XML Files|*.xml" };
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    XmlHandler.SaveToFile(saveFileDialog.FileName, _facade.GetMembers());
                    MessageBox.Show("Members saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}", "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var factory = new MemberFactory();
                _facade.AddMember(factory);
                MainDataGrid.ItemsSource = _facade.GetMembers();
                MessageBox.Show("Member added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding member: {ex.Message}", "Add Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MainDataGrid.SelectedItem is BandMember selected)
                {
                    _facade.DeleteMember(selected);
                    MainDataGrid.ItemsSource = _facade.GetMembers();
                    MessageBox.Show("Member deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("No member selected for deletion.", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting member: {ex.Message}", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainDataGrid.ItemsSource = _facade.SortByRole().ToList();
                MessageBox.Show("Members sorted by role successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sorting members: {ex.Message}", "Sort Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var filterText = FilterTextBox.Text.Trim();
                if (string.IsNullOrEmpty(filterText))
                {
                    MainDataGrid.ItemsSource = _facade.GetMembers();
                    MessageBox.Show("Displaying all members.", "Filter", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    var filtered = _facade.FilterByRole(filterText).ToList();
                    MainDataGrid.ItemsSource = filtered;

                    if (!filtered.Any())
                    {
                        MessageBox.Show("No members found with the given role.", "Filter Result", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Found {filtered.Count} member(s) matching the role.", "Filter Result", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering members: {ex.Message}", "Filter Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
