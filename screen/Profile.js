import React, { useState, useEffect } from 'react';
import { View, Text, StyleSheet, TouchableOpacity, Button, FlatList } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { Ionicons } from '@expo/vector-icons';

const Profile = ({ navigation }) => {
  const [userData, setUserData] = useState([]);
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  useEffect(() => {
      fetchUserData();
    }, []);

    const fetchUserData = () => {
      fetch('https://fptbottournamentweb.azurewebsites.net/api/user/get-all')
        .then(response => response.json())
        .then(data => {
          setUserData(data);
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
      colors={['#96E9C6', '#DC84F3']}
      style={styles.gradientContainer}
    >

      <View style={styles.header}>
        <TouchableOpacity onPress={handleHamburgerPress}>
          <Ionicons name={isMenuOpen ? 'ios-close' : 'ios-menu'} size={32} color="white" />
        </TouchableOpacity>
        <Text style={styles.titleText}>UserProfile</Text>
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
        data={userData}
        keyExtractor={(item) => item.id ? item.id.toString() : null} // Check if item.id exists
        renderItem={({ item }) => (
          <View style={styles.container}>
            <Text>Username: {item.userName}</Text>
            <Text>Email: {item.userEmail}</Text>
            <Text>Full Name: {item.fullName}</Text>
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
  container: {
    backgroundColor: 'white',
    padding: 16,
    marginBottom: 16,
    borderRadius: 8,
  },
  titleText: {
    fontSize: 24,
    fontWeight: 'bold',
    color: 'white',
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

export default Profile