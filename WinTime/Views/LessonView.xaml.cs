using System;
using System.Windows;
using System.Windows.Controls;
using WinTime.Driver.Models.OldWeb;
using Wpf.Ui.Controls;

namespace WinTime.Views;

public partial class LessonView : UserControl
{
    public LessonView()
    {
        InitializeComponent();
    }
    // ADD DependencyProperty
    public static readonly DependencyProperty LessonSourceProperty =
        DependencyProperty.Register(
            nameof(LessonSource),
            typeof(Lesson),
            typeof(LessonView),
            new PropertyMetadata(default(Lesson), OnLessonSourceChanged));
    
    public Lesson LessonSource
    {
        get => (Lesson)GetValue(LessonSourceProperty);
        set => SetValue(LessonSourceProperty, value);
    }
    
    // LessonSource Event handler
    private static void OnLessonSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        LessonView view = (LessonView)d;
        Lesson lesson = (Lesson)e.NewValue;

        //
        // make sure: struct may be empty
        // 
        if (lesson.MessageType == string.Empty) return;
        
        view.Title.Text = lesson.Title;
        view.Type.Text = lesson.Type;
        view.AudienceRun.Text = lesson.Audience.Name;
        view.ProfessorRun.Text = lesson.Professor.FullName;
        view.GroupsView.ItemsSource = lesson.Groups;
        view.LessonNumberRun.Text = lesson.Number.ToString();
        
        // hide implementation on another entity!
        view.StartsRun.Text = new DateTime().AddSeconds(lesson.Starts).ToShortTimeString();
        view.EndsRun.Text = new DateTime().AddSeconds(lesson.Ends).ToShortTimeString();
        
    }
}