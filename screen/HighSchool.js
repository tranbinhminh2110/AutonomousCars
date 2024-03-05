import React, { useEffect, useState } from 'react';
import { View, Text, FlatList, Button, Pressable, ScrollView, StyleSheet } from 'react-native';
import Modal from 'react-native-modal';
import { LinearGradient } from 'expo-linear-gradient';

const HighSchool = ({ navigation }) => {
  const [highSchools, setHighSchools] = useState([]);
  const [isModalVisible, setModalVisible] = useState(false);
  const [selectedHighSchool, setSelectedHighSchool] = useState(null);
  const [isUpdateModalVisible, setUpdateModalVisible] = useState(false);

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

  const toggleModal = () => {
    setModalVisible(!isModalVisible);
  };

  const showUpdateModal = (highSchool) => {
    setSelectedHighSchool(highSchool);
    setUpdateModalVisible(true);
  };

  const hideUpdateModal = () => {
    setSelectedHighSchool(null);
    setUpdateModalVisible(false);
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

      <Modal isVisible={isUpdateModalVisible}>
        <View style={styles.modalContainer}>
          <View style={styles.modalContent}>
            <Text style={styles.modalTitle}>High School</Text>
            {selectedHighSchool && (
              <>
                <Text>High School Name: {selectedHighSchool.highSchoolName}</Text>
                <Text>Key ID: {selectedHighSchool.keyId}</Text>
                <Pressable onPress={hideUpdateModal}>
                  <Text style={styles.buttonText}>Cancel</Text>
                </Pressable>
              </>
            )}
          </View>
        </View>
      </Modal>
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
  modalContainer: {
    flexGrow: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
  buttonText: {
    color: 'black',
    fontSize: 25,
    marginBottom: 16,
  },
  modalContent: {
    backgroundColor: 'white',
    padding: 16,
    borderRadius: 8,
  },
  modalTitle: {
    fontSize: 20,
    fontWeight: 'bold',
    marginBottom: 16,
    textAlign: 'center',
  },
});

export default HighSchool;
