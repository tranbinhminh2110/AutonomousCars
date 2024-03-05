import React, { useEffect, useState } from 'react';
import { View, Text, FlatList, Button, StyleSheet } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';

const Map = ({ navigation }) => {
  const [maps, setMaps] = useState([]);

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

  return (
    <LinearGradient
      colors={['#9F8CE3', '#FFBE98']}
      style={styles.gradientContainer}
    >
      <Text style={styles.titleText}>Maps</Text>

      <FlatList
        data={maps}
        keyExtractor={(item) => item.id.toString()}
        renderItem={({ item }) => (
          <View style={styles.mapContainer}>
            <Text>Map Name: {item.mapName}</Text>
            <Text>Key ID: {item.keyId}</Text>
          </View>
        )}
      />
      <Button title="Tournament List" onPress={() => navigation.navigate('TournamentList')} />
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
});

export default Map;
