import React, { useEffect, useState } from 'react';
import { View, Text, FlatList, Button, StyleSheet, TouchableOpacity } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { Ionicons } from '@expo/vector-icons';

const Map = ({ navigation }) => {
  const [maps, setMaps] = useState([]);
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  useEffect(() => {
    fetchMaps();
  }, []);

  const fetchMaps = () => {
    fetch('https://fptbottournamentweb.azurewebsites.net/api/map/get-all')
      .then(response => response.json())
      .then(data => {
        setMaps(data);
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
      colors={['#FF9BD2', '#F4F27E']}
      style={styles.gradientContainer}
    >


      {/* Header */}
            <View style={styles.header}>
              <TouchableOpacity onPress={handleHamburgerPress}>
                <Ionicons name={isMenuOpen ? 'ios-close' : 'ios-menu'} size={32} color="white" />
              </TouchableOpacity>
              <Text style={styles.titleText}>Maps</Text>
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
        data={maps}
        keyExtractor={(item) => item.id.toString()}
        renderItem={({ item }) => (
          <View style={styles.mapContainer}>
            <Text>Map: {item.mapName}</Text>
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
  mapContainer: {
    backgroundColor: 'white',
    padding: 16,
    marginBottom: 16,
    borderRadius: 8,
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

export default Map;
