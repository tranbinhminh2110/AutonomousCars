import React, { useState, useEffect } from 'react';
import { View, Text, StyleSheet, TouchableOpacity, FlatList } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { LinearGradient } from 'expo-linear-gradient';
import { Ionicons } from '@expo/vector-icons';

const Profile = ({ navigation }) => {
  const [userData, setUserData] = useState([]);
  const [isMenuOpen, setIsMenuOpen] = useState(false);
  const [isLogoutPressed, setIsLogoutPressed] = useState(false);
  const [temporaryUserInfo, setTemporaryUserInfo] = useState(null);

  useEffect(() => {
    fetchUserData();
    fetchTemporaryUserInfo();
  }, []);

  useEffect(() => {
    if (isLogoutPressed) {
      AsyncStorage.removeItem('temporaryUserInfo');
      setIsLogoutPressed(false);
      navigation.navigate('Welcome');
    }
  }, [isLogoutPressed]);

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

  const fetchTemporaryUserInfo = async () => {
    try {
      const data = await AsyncStorage.getItem('temporaryUserInfo');
      if (data) {
        setTemporaryUserInfo(JSON.parse(data));
      }
    } catch (error) {
      console.error(error);
    }
  };

  const handleProfilePress = () => {
    navigation.navigate('Profile');
  };

  const handleMenuPress = (screen) => {
    navigation.navigate(screen);
    setIsMenuOpen(false);
  };

  const handleHamburgerPress = () => {
    setIsMenuOpen(!isMenuOpen);
  };

  const handleLogoutPress = () => {
    setIsLogoutPressed(true);
  };

  return (
    <LinearGradient
      colors={['#74E291', '#DFF5FF']}
      style={styles.gradientContainer}
    >
      <View style={styles.header}>
        <TouchableOpacity onPress={handleHamburgerPress}>
          <Ionicons name={isMenuOpen ? 'ios-close' : 'ios-menu'} size={32} color="white" />
        </TouchableOpacity>
        <Text style={styles.titleText}>Profile</Text>
        <TouchableOpacity onPress={handleProfilePress}>
          <Ionicons name="ios-person" size={32} color="white" />
        </TouchableOpacity>
      </View>

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
          <TouchableOpacity onPress={handleLogoutPress} style={styles.logoutButton}>
            <Ionicons name="log-out" size={24} color="red" style={styles.logoutIcon} />
            <Text style={[styles.menuItem, { color: 'red' }]}>Logout</Text>
          </TouchableOpacity>
        </View>
      )}

      <View style={styles.container}>

        <FlatList
          data={temporaryUserInfo ? [temporaryUserInfo] : []}
          keyExtractor={(item, index) => index.toString()}
          renderItem={({ item }) => (
            <View style>
              <View style={styles.userInfoItem}>
                <Text style={styles.userInfoLabel}>User Name:</Text>
                <Text style={styles.userInfoText}>{item.userName}</Text>
              </View>
              <View style={styles.userInfoItem}>
                <Text style={styles.userInfoLabel}>Email:</Text>
                <Text style={styles.userInfoText}>{item.userEmail}</Text>
              </View>
              <View style={styles.userInfoItem}>
                <Text style={styles.userInfoLabel}>Full Name:</Text>
                <Text style={styles.userInfoText}>{item.fullName}</Text>
              </View>
            </View>
          )}
        />


      </View>
    </LinearGradient>
  );
};

const styles = StyleSheet.create({
  gradientContainer: {
    flex: 1,
    padding: 16,
  },
  container: {

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
  logoutButton: {
    flexDirection: 'row',
    alignItems: 'center',
  },
  logoutIcon: {
    marginRight: 8,
  },
  userInfoContainer: {
    backgroundColor: 'white',
    padding: 16,
    marginBottom: 16,
    borderRadius: 8,
  },
  userInfoItem: {
    flexDirection: 'row',
    marginBottom: 8,
    borderBottomWidth: 1, // Thêm đường viền dưới
    paddingBottom: 8, // Khoảng cách giữa dòng và đường viền
    borderBottomColor: 'rgba(255, 255, 255, 0.5)',
  },
  userInfoLabel: {
    marginRight: 8,
    width: 100,
    color: 'white',
    fontSize: 18,
  },
  userInfoText: {
    flex: 1,
    fontWeight: 'bold',
    fontSize: 18,
  },
});

export default Profile;