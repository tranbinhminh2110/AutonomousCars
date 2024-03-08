import React, { useEffect, useState } from 'react';
import { View, Text, FlatList, Button, StyleSheet } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';

const TeamInMatch = ({ navigation, route }) => {
  const [teams, setTeams] = useState([]);
  const { matchId } = route.params;

  useEffect(() => {
    fetchTeams();
  }, []);

  const fetchTeams = () => {
    // Fetch teams with a specific matchId from the API endpoint
    fetch(`https://fptbottournamentweb.azurewebsites.net/api/team-in-match/get-all-teams-in-match-id/${matchId}`)
      .then(response => response.json())
      .then(data => {
        setTeams(data);
      })
      .catch(error => {
        console.error(error);
      });
  };

  return (
    <LinearGradient
      colors={['#EADFB4', '#83C0C1']}
      style={styles.gradientContainer}
    >
      <Text style={styles.titleText}>Teams in Match</Text>

      <FlatList
        data={teams}
        keyExtractor={(item) => item.id.toString()}
        renderItem={({ item }) => (
          <View style={styles.teamContainer}>
            <Text style={styles.teamName}>{item.name}</Text>
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
  teamContainer: {
    backgroundColor: 'white',
    padding: 16,
    marginBottom: 16,
    borderRadius: 8,
  },
  teamName: {
    fontSize: 16,
    color: 'black',
  },
});

export default TeamInMatch;