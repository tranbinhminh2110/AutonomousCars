import React, { useEffect, useState } from 'react';
import { View, Text, FlatList, Button, StyleSheet, TouchableOpacity } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';

const TournamentList = ({ navigation }) => {
  const [tournaments, setTournaments] = useState([]);

  useEffect(() => {
    fetchTournaments();
  }, []);

  const fetchTournaments = () => {
    fetch('https://fptbottournamentweb.azurewebsites.net/api/tournament/get-all')
      .then(response => response.json())
      .then(data => {
        setTournaments(data);
      })
      .catch(error => {
        console.error(error);
      });
  };

  const handleTournamentPress = (tournamentId) => {
    navigation.navigate('Match', { tournamentId });
  };

  return (
    <LinearGradient
      colors={['#96E9C6', '#86A7FC']}
      style={styles.gradientContainer}
    >
      <Text style={styles.titleText}>Tournaments</Text>

      <FlatList
        data={tournaments}
        keyExtractor={(item) => item.id.toString()}
        renderItem={({ item }) => (
          <TouchableOpacity onPress={() => handleTournamentPress(item.id)}>
            <View style={styles.tournamentContainer}>
              <Text>Tournament Name: {item.tournamentName}</Text>
              <Text>Key ID: {item.keyId}</Text>
              <Text>Start Date: {new Date(item.startDate).toLocaleDateString()}</Text>
              <Text>End Date: {new Date(item.endDate).toLocaleDateString()}</Text>
            </View>
          </TouchableOpacity>
        )}
      />
      <Button title="Map" onPress={() => navigation.navigate('Map')} />
      <Button title="HighSchool" onPress={() => navigation.navigate('HighSchool')} />
      <Button title="ActivityType" onPress={() => navigation.navigate('ActivityType')} />
      <Button title="Round" onPress={() => navigation.navigate('Round')} />
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
  tournamentContainer: {
    backgroundColor: 'white',
    padding: 16,
    marginBottom: 16,
    borderRadius: 8,
  },
});

export default TournamentList;
