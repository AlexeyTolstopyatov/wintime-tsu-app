using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Controls;

namespace WinTime.Input;

public static class AutoSuggestBoxBehavior
{
    #region SuggestionChosen
    public static readonly DependencyProperty SuggestionChosenCommandProperty =
        DependencyProperty.RegisterAttached(
            "SuggestionChosenCommand",
            typeof(ICommand),
            typeof(AutoSuggestBoxBehavior),
            new PropertyMetadata(null, OnSuggestionChosenCommandChanged));

    public static void SetSuggestionChosenCommand(DependencyObject obj, ICommand value)
    {
        obj.SetValue(SuggestionChosenCommandProperty, value);
    }

    public static ICommand GetSuggestionChosenCommand(DependencyObject obj)
    {
        return (ICommand)obj.GetValue(SuggestionChosenCommandProperty);
    }

    private static void OnSuggestionChosenCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not AutoSuggestBox autoSuggestBox) return;
        
        autoSuggestBox.SuggestionChosen -= OnSuggestionChosen;
        if (e.NewValue is ICommand)
        {
            autoSuggestBox.SuggestionChosen += OnSuggestionChosen;
        }
    }

    private static void OnSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
    {
        ICommand? command = GetSuggestionChosenCommand(sender);
        if (command != null! && command.CanExecute(args.SelectedItem))
        {
            command.Execute(args.SelectedItem);
        }
    }
    #endregion
    
    #region QuerySubmitted
    public static readonly DependencyProperty QuerySubmittedCommandProperty =
        DependencyProperty.RegisterAttached(
            "QuerySubmittedCommand",
            typeof(ICommand),
            typeof(AutoSuggestBoxBehavior),
            new PropertyMetadata(null, OnQuerySubmittedCommandChanged));

    // ADD attached property
    public static void SetQuerySubmittedCommand(DependencyObject obj, ICommand value)
    {
        obj.SetValue(QuerySubmittedCommandProperty, value);
    }

    // GET attached property
    public static ICommand GetQuerySubmittedCommand(DependencyObject obj)
    {
        return (ICommand)obj.GetValue(QuerySubmittedCommandProperty);
    }

    // SET attached property
    private static void OnQuerySubmittedCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not AutoSuggestBox autoSuggestBox) return;
        // subscription check
        autoSuggestBox.QuerySubmitted -= OnQuerySubmitted;

        // not null -> subscribe
        
        if (e.NewValue is ICommand)
        {
            autoSuggestBox.QuerySubmitted += OnQuerySubmitted;
        }
    }

    private static void OnQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
    {
        var command = GetQuerySubmittedCommand(sender);

        // command == null (i think it's optional)
        if (command.CanExecute(args.QueryText))
        {
            command.Execute(args.QueryText);
        }
    }
    #endregion
}