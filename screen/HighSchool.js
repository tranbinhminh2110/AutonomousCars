import React, { useEffect, useState } from 'react';
import { View, Text, FlatList, Button, Pressable, ScrollView, StyleSheet, TouchableOpacity } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { Ionicons } from '@expo/vector-icons';

const HighSchool = ({ navigation }) => {
  const [highSchools, setHighSchools] = useState([]);
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  useEffect(() => {
    fetchHighSchools();
  }, []);

  const fetchHighSchools = () => {
    fetch('https://fptbottournamentweb.azurewebsites.net/api/highSchool/get-all')
      .then(response => response.json())
      .then(data => {
        setHighSchools(data);
      })
      .catch(error => {
        console.error(error);
      });
  };

  const handleProfilePress = () => {
      navigation.navigate('Profile'); // Chuyển hướng tới trang Profile
    };

    const handleMenuPress = (screen) => {
      navigation.navigate(screen);
      setIsMenuOpen(false); // Đóng menu sau khi chuyển hướng
    };

    const handleHamburgerPress = () => {
      setIsMenuOpen(!isMenuOpen); // Chuyển đổi giá trị giữa true và false
    };

  return (
    <LinearGradient
      colors={['#59D5E0', '#F2AFEF']}
      style={styles.gradientContainer}
    >


      {/* Header */}
            <View style={styles.header}>
              <TouchableOpacity onPress={handleHamburgerPress}>
                <Ionicons name={isMenuOpen ? 'ios-close' : 'ios-menu'} size={32} color="white" />
              </TouchableOpacity>
              <Text style={styles.titleText}>High Schools</Text>
              <TouchableOpacity onPress={handleProfilePress}>
                <Ionicons name="ios-person" size={32} color="white" />
              </TouchableOpacity>
            </View>

            {/* Hamburger Menu */}
            {isMenuOpen && (
              <View style={styles.menu}>
                <TouchableOpacity onPress={() => handleMenuPress('Map')}>
                  <Text style={styles.menuItem}>MAP</Text>
                </TouchableOpacity>
                <TouchableOpacity onPress={() => handleMenuPress('HighSchool')}>
                  <Text style={styles.menuItem}>HIGHSCHOOL</Text>
                </TouchableOpacity>
                <TouchableOpacity onPress={() => handleMenuPress('ActivityType')}>
                  <Text style={styles.menuItem}>ACTIVITYTYPE</Text>
                </TouchableOpacity>
                <TouchableOpacity onPress={() => handleMenuPress('Round')}>
                  <Text style={styles.menuItem}>ROUND</Text>
                </TouchableOpacity>
                <TouchableOpacity onPress={() => handleMenuPress('TournamentList')}>
                  <Text style={styles.menuItem}>TOURNAMENT</Text>
                </TouchableOpacity>
              </View>
            )}

      <FlatList
        data={highSchools}
        keyExtractor={(item) => item.id.toString()}
        renderItem={({ item }) => (
          <View style={styles.highSchoolContainer}>
            <Text>High School: {item.highSchoolName}</Text>
            <Text>Key ID: {item.keyId}</Text>
          </View>
        )}
      />

    </LinearGradient>
  );
};

const styles = StyleSheet.create({
  gradientContainer: {
    flex: 1,
    padding: 16,
  },
  titleText: {
    fontSize: 24,
    fontWeight: 'bold',
    color: 'white',
    marginBottom: 16,
  },
  highSchoolContainer: {
    backgroundColor: 'white',
    padding: 16,
    marginBottom: 16,
    borderRadius: 8,
  },
  buttonText: {
    color: 'black',
    fontSize: 25,
    marginBottom: 16,
  },
  header: {
      flexDirection: 'row',
      justifyContent: 'space-between',
      alignItems: 'center',
      marginBottom: 16,
    },
    menu: {
      backgroundColor: 'rgba(255, 255, 255, 0.9)',
      position: 'absolute',
      top: 60,
      left: 0,
      width: 250,
      borderRadius: 8,
      paddingVertical: 20,
      paddingHorizontal: 12,
      zIndex: 1,
    },
    menuItem: {
      fontSize: 18,
      fontWeight: 'bold',
      marginBottom: 8,
    },
});

export default HighSchool;
