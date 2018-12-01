using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GW2StatCombo
{




    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Stats.Attribute> checkedList = new List<Stats.Attribute>();

        public MainWindow()
        {
            InitializeComponent();
            PopulateTable();
        }

        private void PopulateTable()
        {
            foreach (Stats.StatComboName combo in Enum.GetValues(typeof(Stats.StatComboName)))
            {
                StackPanel panel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Name = combo.ToString()

                };
                Label text = new Label
                {
                    Content = combo
                };
                panel.Children.Add(text);
                Stats.StatCombination attributes = Stats.StatCombination.Get(combo);
                foreach (Stats.Attribute attribute in attributes.Major)
                {
                    panel.Children.Add(new Image
                    {
                        Source = Resources[Enum.GetName(typeof(Stats.Attribute), attribute)] as BitmapImage,
                        Height = 18,
                        Name = attribute.ToString()
                    });
                }
                foreach (Stats.Attribute attribute in attributes.Minor)
                {
                    panel.Children.Add(new Image
                    {
                        Source = Resources[Enum.GetName(typeof(Stats.Attribute), attribute)] as BitmapImage,
                        Height = 18,
                        Name = attribute.ToString()
                    });
                }

                StatCombinationBox.Items.Add(panel);
            }
        }

        public class Stats
        {

            public enum Attribute
            {
                Power,
                Precision,
                Toughness,
                Vitality,
                ConditionDamage,
                HealingPower,
                Concentration,
                Expertise,
                Ferocity
            }

            public enum StatComboName
            {
                Apothecary,
                Assassin,
                Berserker,
                Bringer,
                Captain,
                Carrion,
                Cavalier,
                Celestial,
                Cleric,
                Commander,
                Crusader,
                Dire,
                Giver,
                Grieving,
                Harrier,
                Knight,
                Magi,
                Marauder,
                Marshal,
                Minstrel,
                Nomad,
                Plaguedoctor,
                Rabid,
                Rampager,
                Sentinel,
                Seraph,
                Settler,
                Shaman,
                Sinister,
                Soldier,
                Trailblazer,
                Valkyrie,
                Vigilant,
                Viper,
                Wanderer,
                Zealot
            }

            public class StatCombination
            {
                public List<Attribute> Major = new List<Attribute>();
                public List<Attribute> Minor = new List<Attribute>();

                public StatCombination(Attribute major, Attribute minor1, Attribute minor2)
                {

                    Major.Add(major);
                    Minor.Add(minor1);
                    Minor.Add(minor2);

                }

                public StatCombination(Attribute major, Attribute major2, Attribute minor1, Attribute minor2)
                {

                    Major.Add(major);
                    Major.Add(major2);
                    Minor.Add(minor1);
                    Minor.Add(minor2);

                }

                public StatCombination(Attribute minor1, Attribute minor2, Attribute minor3, Attribute minor4, Attribute minor5, Attribute minor6, Attribute minor7)
                {

                    Minor.Add(minor1);
                    Minor.Add(minor2);
                    Minor.Add(minor3);
                    Minor.Add(minor4);
                    Minor.Add(minor5);
                    Minor.Add(minor6);
                    Minor.Add(minor7);

                }

                internal static StatCombination Get(StatComboName combo)
                {
                    switch (combo)
                    {
                        case StatComboName.Apothecary:
                            return new StatCombination(Attribute.HealingPower, Attribute.ConditionDamage, Attribute.Toughness);
                        case StatComboName.Assassin:
                            return new StatCombination(Attribute.Precision, Attribute.Ferocity, Attribute.Power);
                        case StatComboName.Berserker:
                            return new StatCombination(Attribute.Power, Attribute.Ferocity, Attribute.Precision);
                        case StatComboName.Bringer:
                            return new StatCombination(Attribute.Expertise, Attribute.Precision, Attribute.Vitality);
                        case StatComboName.Captain:
                            return new StatCombination(Attribute.Precision, Attribute.Power, Attribute.Toughness);
                        case StatComboName.Carrion:
                            return new StatCombination(Attribute.ConditionDamage, Attribute.Power, Attribute.Vitality);
                        case StatComboName.Cavalier:
                            return new StatCombination(Attribute.Toughness, Attribute.Ferocity, Attribute.Power);
                        case StatComboName.Celestial:
                            return new StatCombination(Attribute.Power, Attribute.Precision, Attribute.Toughness, Attribute.Vitality, Attribute.ConditionDamage, Attribute.Ferocity, Attribute.HealingPower);
                        case StatComboName.Cleric:
                            return new StatCombination(Attribute.HealingPower, Attribute.Power, Attribute.Toughness);
                        case StatComboName.Commander:
                            return new StatCombination(Attribute.Power, Attribute.Precision, Attribute.Toughness, Attribute.Concentration);
                        case StatComboName.Crusader:
                            return new StatCombination(Attribute.Power, Attribute.Toughness, Attribute.Ferocity, Attribute.Toughness);
                        case StatComboName.Dire:
                            return new StatCombination(Attribute.ConditionDamage, Attribute.Toughness, Attribute.Vitality);
                        case StatComboName.Giver:
                            return new StatCombination(Attribute.Toughness, Attribute.Concentration, Attribute.HealingPower);
                        case StatComboName.Grieving:
                            return new StatCombination(Attribute.Power, Attribute.ConditionDamage, Attribute.Precision, Attribute.Ferocity);
                        case StatComboName.Harrier:
                            return new StatCombination(Attribute.Power, Attribute.Concentration, Attribute.HealingPower);
                        case StatComboName.Knight:
                            return new StatCombination(Attribute.Toughness, Attribute.Power, Attribute.Precision);
                        case StatComboName.Magi:
                            return new StatCombination(Attribute.HealingPower, Attribute.Precision, Attribute.Vitality);
                        case StatComboName.Marauder:
                            return new StatCombination(Attribute.Power, Attribute.Precision, Attribute.Ferocity, Attribute.Vitality);
                        case StatComboName.Marshal:
                            return new StatCombination(Attribute.Power, Attribute.HealingPower, Attribute.Precision, Attribute.ConditionDamage);
                        case StatComboName.Minstrel:
                            return new StatCombination(Attribute.HealingPower, Attribute.Toughness, Attribute.Vitality, Attribute.Concentration);
                        case StatComboName.Nomad:
                            return new StatCombination(Attribute.Toughness, Attribute.HealingPower, Attribute.Vitality);
                        case StatComboName.Plaguedoctor:
                            return new StatCombination(Attribute.ConditionDamage, Attribute.Vitality, Attribute.Concentration, Attribute.HealingPower);
                        case StatComboName.Rabid:
                            return new StatCombination(Attribute.ConditionDamage, Attribute.Precision, Attribute.Toughness);
                        case StatComboName.Rampager:
                            return new StatCombination(Attribute.Precision, Attribute.Power, Attribute.ConditionDamage);
                        case StatComboName.Sentinel:
                            return new StatCombination(Attribute.Vitality, Attribute.Power, Attribute.Toughness);
                        case StatComboName.Seraph:
                            return new StatCombination(Attribute.ConditionDamage, Attribute.Precision, Attribute.Concentration, Attribute.HealingPower);
                        case StatComboName.Settler:
                            return new StatCombination(Attribute.Toughness, Attribute.ConditionDamage, Attribute.HealingPower);
                        case StatComboName.Shaman:
                            return new StatCombination(Attribute.Vitality, Attribute.ConditionDamage, Attribute.HealingPower);
                        case StatComboName.Sinister:
                            return new StatCombination(Attribute.ConditionDamage, Attribute.Power, Attribute.Precision);
                        case StatComboName.Soldier:
                            return new StatCombination(Attribute.Power, Attribute.Toughness, Attribute.Vitality);
                        case StatComboName.Trailblazer:
                            return new StatCombination(Attribute.Toughness, Attribute.ConditionDamage, Attribute.Vitality, Attribute.Expertise);
                        case StatComboName.Valkyrie:
                            return new StatCombination(Attribute.Power, Attribute.Vitality, Attribute.Ferocity);
                        case StatComboName.Vigilant:
                            return new StatCombination(Attribute.Power, Attribute.Toughness, Attribute.Concentration, Attribute.Expertise);
                        case StatComboName.Viper:
                            return new StatCombination(Attribute.Power, Attribute.ConditionDamage, Attribute.Precision, Attribute.Expertise);
                        case StatComboName.Wanderer:
                            return new StatCombination(Attribute.Power, Attribute.Vitality, Attribute.Toughness, Attribute.Concentration);
                        case StatComboName.Zealot:
                            return new StatCombination(Attribute.Power, Attribute.Precision, Attribute.HealingPower);
                        default:
                            return new StatCombination(Attribute.Power, Attribute.Power, Attribute.Power);
                    }

                }

                internal bool Contains(List<Attribute> checkedList)
                {
                    List<Attribute> all = new List<Attribute>();
                    all.AddRange(Major);
                    all.AddRange(Minor);

                    return checkedList.Intersect(all).Count() == checkedList.Count();

                }
            }

        }

        private void Power_Checked(object sender, RoutedEventArgs e)
        {
            checkedList.Add(Stats.Attribute.Power);
            FilterList();
        }

        private void Precision_Checked(object sender, RoutedEventArgs e)
        {
            checkedList.Add(Stats.Attribute.Precision);
            FilterList();
        }

        private void Toughness_Checked(object sender, RoutedEventArgs e)
        {
            checkedList.Add(Stats.Attribute.Toughness);
            FilterList();
        }

        private void Vitality_Checked(object sender, RoutedEventArgs e)
        {
            checkedList.Add(Stats.Attribute.Vitality);
            FilterList();
        }

        private void ConditionDamage_Checked(object sender, RoutedEventArgs e)
        {
            checkedList.Add(Stats.Attribute.ConditionDamage);
            FilterList();
        }

        private void HealingPower_Checked(object sender, RoutedEventArgs e)
        {
            checkedList.Add(Stats.Attribute.HealingPower);
            FilterList();
        }

        private void Concentration_Checked(object sender, RoutedEventArgs e)
        {
            checkedList.Add(Stats.Attribute.Concentration);
            FilterList();
        }

        private void Expertise_Checked(object sender, RoutedEventArgs e)
        {
            checkedList.Add(Stats.Attribute.Expertise);
            FilterList();
        }

        private void Ferocity_Checked(object sender, RoutedEventArgs e)
        {
            checkedList.Add(Stats.Attribute.Ferocity);
            FilterList();
        }

        private void Power_Unchecked(object sender, RoutedEventArgs e)
        {
            checkedList.Remove(Stats.Attribute.Power);
            FilterList();
        }

        private void Precision_Unchecked(object sender, RoutedEventArgs e)
        {
            checkedList.Remove(Stats.Attribute.Precision);
            FilterList();
        }

        private void Toughness_Unchecked(object sender, RoutedEventArgs e)
        {
            checkedList.Remove(Stats.Attribute.Toughness);
            FilterList();
        }

        private void Vitality_Unchecked(object sender, RoutedEventArgs e)
        {
            checkedList.Remove(Stats.Attribute.Vitality);
            FilterList();
        }

        private void ConditionDamage_Unchecked(object sender, RoutedEventArgs e)
        {
            checkedList.Remove(Stats.Attribute.ConditionDamage);
            FilterList();
        }

        private void HealingPower_Unchecked(object sender, RoutedEventArgs e)
        {
            checkedList.Remove(Stats.Attribute.HealingPower);
            FilterList();
        }

        private void Concentration_Unchecked(object sender, RoutedEventArgs e)
        {
            checkedList.Remove(Stats.Attribute.Concentration);
            FilterList();
        }

        private void Expertise_Unchecked(object sender, RoutedEventArgs e)
        {
            checkedList.Remove(Stats.Attribute.Expertise);
            FilterList();
        }

        private void Ferocity_Unchecked(object sender, RoutedEventArgs e)
        {
            checkedList.Remove(Stats.Attribute.Ferocity);
            FilterList();
        }

        private void FilterList()
        {
            RefreshList();
            foreach (StackPanel combo in StatCombinationBox.Items)
            {
                foreach (Stats.StatComboName name in Enum.GetValues(typeof(Stats.StatComboName)))
                {
                    Stats.StatCombination combination = Stats.StatCombination.Get(name);

                    if (combo.Name.ToString().Equals(name.ToString()))
                    {
                        if (combination.Contains(checkedList))
                        {
                            combo.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            combo.Visibility = Visibility.Collapsed;
                        }
                    }
                }
            }

        }



        private void RefreshList()
        {
            foreach (StackPanel combo in StatCombinationBox.Items)
            {
                combo.Visibility = Visibility.Visible;
            };
        }
    }


}
