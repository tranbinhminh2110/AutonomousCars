import React, { useState, useEffect } from 'react';
import { View, Text, FlatList, Button, StyleSheet, Pressable } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';

const Match = ({ navigation, route }) => {
  const [matches, setMatches] = useState([]);
  const { tournamentId } = route.params;

  useEffect(() => {
    fetchMatches();
  }, []);

  const fetchMatches = () => {
    fetch('https://fptbottournamentweb.azurewebsites.net/api/match/get-all')
      .then(response => response.json())
      .then(data => {
        const filteredMatches = data.filter(match => match.tournamentId === tournamentId);
        setMatches(filteredMatches);
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
      <Text style={styles.titleText}>Matches</Text>

      <FlatList
        data={matches}
        keyExtractor={(item) => item.id}
        renderItem={({ item }) => (
          <Pressable onPress={() => navigation.navigate('TeamInMatch', { matchId: item.id })}>
            <View style={styles.matchContainer}>
              <Text>Key Id: {item.keyId}</Text>
              <Text>Map Name: {item.mapName}</Text>
              <Text>Round Name: {item.roundName}</Text>
              <Text>Tournament Name: {item.tournamentName}</Text>
            </View>
          </Pressable>
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