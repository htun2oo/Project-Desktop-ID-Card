<UserControl x:Class="IDCard.Desktop.Views.CredentialsView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             mc:Ignorable="d" 
             d:DesignHeight="450" d:DesignWidth="800">

    <UserControl.Resources>
        <!-- 1. Grid View Template -->
        <DataTemplate x:Key="GridTemplate">
            <ItemsControl ItemsSource="{Binding CardDesigns}">
                <ItemsControl.ItemsPanel>
                    <ItemsPanelTemplate>
                        <WrapPanel/>
                    </ItemsPanelTemplate>
                </ItemsPanelTemplate>
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <Border Width="180" Height="110" Margin="10" Background="#F9F9F9" BorderBrush="#CCCCCC" BorderThickness="1" CornerRadius="6">
                            <StackPanel VerticalAlignment="Center" HorizontalAlignment="Center">
                                <TextBlock Text="{Binding DesignName}" FontWeight="Bold" FontSize="14" TextAlignment="Center" Margin="0,0,0,5"/>
                                <TextBlock Text="{Binding OwnerUsername}" FontSize="12" Foreground="Gray" TextAlignment="Center"/>
                            </StackPanel>
                        </Border>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
        </DataTemplate>

        <!-- 2. List View Template -->
        <DataTemplate x:Key="ListTemplate">
            <ListView ItemsSource="{Binding CardDesigns}" Height="350" BorderBrush="#E0E0E0">
                <ListView.View>
                    <GridView>
                        <GridViewColumn Header="Credential Design Name" Width="300" DisplayMemberBinding="{Binding DesignName}"/>
                        <GridViewColumn Header="Owner Name" Width="200" DisplayMemberBinding="{Binding OwnerUsername}"/>
                        <GridViewColumn Header="Actions" Width="150"/>
                    </GridView>
                </ListView.View>
            </ListView>
        </DataTemplate>
    </UserControl.Resources>
    
    <Grid Background="White">
        <!-- ညာဘက်ဘေးတွင် Vertical ScrollBar ပါဝင်စေရန် ScrollViewer ထည့်သွင်းထားသည် -->
        <ScrollViewer VerticalScrollBarVisibility="Auto" HorizontalScrollBarVisibility="Disabled">
            <StackPanel Margin="15">
                
                <!-- View Toggle Buttons -->
                <StackPanel Orientation="Horizontal" Margin="0,0,0,15">
                    <Button Command="{Binding SwitchToGridViewCommand}" Width="35" Height="30" Margin="0,0,5,0" ToolTip="Grid View" Background="#E0E0E0" BorderBrush="#CCCCCC">
                        <TextBlock Text="🧮" FontSize="14" HorizontalAlignment="Center" VerticalAlignment="Center"/>
                    </Button>
                    <Button Command="{Binding SwitchToListViewCommand}" Width="35" Height="30" ToolTip="List View" Background="#E0E0E0" BorderBrush="#CCCCCC">
                        <TextBlock Text="☰" FontSize="14" HorizontalAlignment="Center" VerticalAlignment="Center"/>
                    </Button>
                </StackPanel>

                <!-- Content Control ကို Template ဖြင့် ချိတ်ဆက်ခြင်း -->
                <ContentControl Content="{Binding}" ContentTemplate="{Binding CurrentTemplate}"/>

            </StackPanel>
        </ScrollViewer>
    </Grid>
</UserControl>
