import React, { useState, useEffect } from 'react';
import { View, Text, FlatList, Button, TextInput, Pressable, StyleSheet } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';

const ActivityType = ({ navigation }) => {
  const [activityTypes, setActivityTypes] = useState([]);

  useEffect(() => {
    fetchActivityTypes();
  }, []);

  const fetchActivityTypes = () => {
    fetch('https://fptbottournamentweb.azurewebsites.net/api/activity-type/get-all')
      .then(response => response.json())
      .then(data => {
        setActivityTypes(data);
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
      <Text style={styles.titleText}>Activity Types</Text>

      <FlatList
        data={activityTypes}
        keyExtractor={(item) => item.id.toString()}
        renderItem={({ item }) => (
          <View style={styles.activityTypeContainer}>
            <Text>Type Name: {item.typeName}</Text>
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
  activityTypeContainer: {
    backgroundColor: 'white',
    padding: 16,
    marginBottom: 16,
    borderRadius: 8,
  },
  input: {
    color: 'black',
    fontSize: 25,
    textAlign: 'center',
    marginBottom: 16,
  },
  buttonText: {
    color: 'black',
    fontSize: 25,
    marginBottom: 16,
  },

});

export default ActivityType;
