import React, { useEffect, useState } from 'react';
import { View, Text, FlatList, Button, Pressable, ScrollView, StyleSheet } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';

const HighSchool = ({ navigation }) => {
  const [highSchools, setHighSchools] = useState([]);

  useEffect(() => {
    fetchHighSchools();
  }, []);

  const fetchHighSchools = () => {
    fetch('https://fptbottournamentweb.azurewebsites.net/api/highSchool/get-all')
      .then(response => response.json())
      .then(data => {
        setHighSchools(data);
      })
      .catch(error => {
        console.error(error);
      });
  };

  return (
    <LinearGradient
      colors={['#59D5E0', '#F2AFEF']}
      style={styles.gradientContainer}
    >
      <Text style={styles.titleText}>High Schools</Text>

      <FlatList
        data={highSchools}
        keyExtractor={(item) => item.id.toString()}
        renderItem={({ item }) => (
          <View style={styles.highSchoolContainer}>
            <Text>High School Name: {item.highSchoolName}</Text>
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
  highSchoolContainer: {
    backgroundColor: 'white',
    padding: 16,
    marginBottom: 16,
    borderRadius: 8,
  },
  buttonText: {
    color: 'black',
    fontSize: 25,
    marginBottom: 16,
  },
});

export default HighSchool;
