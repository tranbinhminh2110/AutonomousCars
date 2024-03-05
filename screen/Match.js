import React, { useState, useEffect } from 'react';
import { View, Text, FlatList, Button, StyleSheet } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';

const Match = ({ navigation }) => {
  const [matches, setMatches] = useState([]);

  useEffect(() => {
    fetchMatches();
  }, []);

  const fetchMatches = () => {
    fetch('https://fptbottournamentweb.azurewebsites.net/api/match/get-all')
      .then(response => response.json())
      .then(data => {
        setMatches(data);
      })
      .catch(error => {
        console.error(error);
      });
  };

  return (
    <LinearGradient
      colors={['#FF9BD2', '#F4F27E']}
      style={styles.gradientContainer}
    >
      <Text style={styles.titleText}>Match</Text>

      <FlatList
        data={matches}
        keyExtractor={(item) => item.id.toString()}
        renderItem={({ item }) => (
          <View style={styles.matchContainer}>
            <Text>Key Id: {item.keyId}</Text>
            <Text>Map Name: {item.mapResponseModel.mapName}</Text>
            <Text>Round Name: {item.roundResponseModel.roundName}</Text>
            <Text>Tournament Name: {item.tournamentResponseModel.tournamentName}</Text>
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
  matchContainer: {
    backgroundColor: 'white',
    padding: 16,
    marginBottom: 16,
    borderRadius: 8,
  },
});

export default Match;
