import React, { useEffect, useState } from 'react';
import { View, Text, FlatList, Button, TextInput, Pressable, ScrollView, StyleSheet } from 'react-native';
import Modal from 'react-native-modal';
import { LinearGradient } from 'expo-linear-gradient';

const HighSchool = ({ navigation }) => {
  const [highSchools, setHighSchools] = useState([]);
  const [newKeyId, setNewKeyId] = useState('');
  const [newHighSchoolName, setNewHighSchoolName] = useState('');
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

  const createHighSchool = () => {
    fetch('https://fptbottournamentweb.azurewebsites.net/api/highSchool/create', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        keyId: newKeyId || Math.floor(Math.random() * 1000),
        highSchoolName: newHighSchoolName,
      }),
    })
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        fetchHighSchools();
        setNewKeyId('');
        setNewHighSchoolName('');
        toggleModal();
      })
      .catch(error => {
        console.error(error);
      });
  };

  const updateHighSchool = () => {
    const { id, keyId, highSchoolName } = selectedHighSchool;

    fetch(`https://fptbottournamentweb.azurewebsites.net/api/highSchool/update/${id}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        keyId,
        highSchoolName: newHighSchoolName || highSchoolName,
      }),
    })
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        fetchHighSchools();
        hideUpdateModal();
      })
      .catch(error => {
        console.error(error);
      });
  };

  const deleteHighSchool = (id) => {
    fetch(`https://fptbottournamentweb.azurewebsites.net/api/highSchool/delete/${id}`, {
      method: 'DELETE',
    })
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        fetchHighSchools();
      })
      .catch(error => {
        console.error(error);
      });
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
            <Button title="Update" onPress={() => showUpdateModal(item)} />
            <Button title="Delete" onPress={() => deleteHighSchool(item.id)} />
          </View>
        )}
      />
      <Button title="Create High School" onPress={toggleModal} />
      <Button title="Map" onPress={() => navigation.navigate('Map')} />
      <Button title="Tournament List" onPress={() => navigation.navigate('TournamentList')} />

      <Modal isVisible={isModalVisible}>
        <ScrollView contentContainerStyle={styles.modalContainer}>
          <View style={styles.modalContent}>
            <Text style={styles.modalTitle}>Create High School</Text>
            <TextInput
              placeholder="Key ID"
              value={newKeyId}
              onChangeText={(text) => setNewKeyId(text)}
              style={styles.input}
            />
            <TextInput
              placeholder="High School Name"
              value={newHighSchoolName}
              onChangeText={(text) => setNewHighSchoolName(text)}
              style={styles.input}
            />
            <Pressable onPress={createHighSchool}>
              <Text style={styles.buttonText}>Create High School</Text>
            </Pressable>
            <Pressable onPress={toggleModal}>
              <Text style={styles.buttonText}>Cancel</Text>
            </Pressable>
          </View>
        </ScrollView>
      </Modal>

      <Modal isVisible={isUpdateModalVisible}>
        <View style={styles.modalContainer}>
          <View style={styles.modalContent}>
            <Text style={styles.modalTitle}>Update High School</Text>
            {selectedHighSchool && (
              <>
                <TextInput
                  placeholder="Key ID"
                  value={selectedHighSchool.keyId.toString()}
                  onChangeText={(text) => setSelectedHighSchool({ ...selectedHighSchool, keyId: text })}
                  style={styles.input}
                  placeholderTextColor="black"
                />
                <TextInput
                  placeholder="High School Name"
                  value={selectedHighSchool.highSchoolName}
                  onChangeText={(text) => setSelectedHighSchool({ ...selectedHighSchool, highSchoolName: text })}
                  style={styles.input}
                  placeholderTextColor="black"
                />
                <Pressable onPress={updateHighSchool}>
                  <Text style={styles.buttonText}>Update High School</Text>
                </Pressable>
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
