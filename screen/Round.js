import React, { useState, useEffect } from 'react';
import { View, Text, FlatList, Button, StyleSheet } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';

const Round = ({ navigation }) => {
  const [rounds, setRounds] = useState([]);

  useEffect(() => {
    fetchRounds();
  }, []);

  const fetchRounds = () => {
    fetch('https://fptbottournamentweb.azurewebsites.net/api/round/get-all')
      .then(response => response.json())
      .then(data => {
        setRounds(data);
      })
      .catch(error => {
        console.error(error);
      });
  };

  return (
    <LinearGradient
      colors={['#FF9BD2', '#ED7D31']}
      style={styles.gradientContainer}
    >
      <Text style={styles.titleText}>Rounds</Text>

      <FlatList
        data={rounds}
        keyExtractor={(item) => item.id.toString()}
        renderItem={({ item }) => (
          <View style={styles.roundContainer}>
            <Text>Round Name: {item.roundName}</Text>
          </View>
        )}
      />
      <Button title="TournamentList" onPress={() => navigation.navigate('TournamentList')} />
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
  roundContainer: {
    backgroundColor: 'white',
    padding: 16,
    marginBottom: 16,
    borderRadius: 8,
  },
});

export default Round;
