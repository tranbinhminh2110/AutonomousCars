import React, { useState, useEffect } from 'react';
import { View, Text, FlatList, Button, TextInput, Pressable, StyleSheet } from 'react-native';
import Modal from 'react-native-modal';
import { LinearGradient } from 'expo-linear-gradient';

const Round = ({ navigation }) => {
  const [rounds, setRounds] = useState([]);
  const [newRoundName, setNewRoundName] = useState('');
  const [isModalVisible, setModalVisible] = useState(false);
  const [selectedRound, setSelectedRound] = useState(null);
  const [isUpdateModalVisible, setUpdateModalVisible] = useState(false);
  const [editRoundName, setEditRoundName] = useState('');
  const [updateId, setUpdateId] = useState(null); // Thêm state updateId

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

  const toggleModal = () => {
    setModalVisible(!isModalVisible);
  };

  const createRound = () => {
    fetch('https://fptbottournamentweb.azurewebsites.net/api/round/create', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        roundName: newRoundName,
      }),
    })
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        fetchRounds();
        setNewRoundName('');
        toggleModal();
      })
      .catch(error => {
        console.error(error);
      });
  };

const updateRound = () => {
    fetch(`https://fptbottournamentweb.azurewebsites.net/api/round/update/${updateId}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        roundName: editRoundName || selectedRound.roundName,
      }),
    })
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        fetchRounds();
        hideUpdateModal();
      })
      .catch(error => {
        console.error(error);
      });
  };


  const deleteRound = (id) => {
    fetch(`https://fptbottournamentweb.azurewebsites.net/api/round/delete/${id}`, {
      method: 'DELETE',
    })
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        fetchRounds();
      })
      .catch(error => {
        console.error(error);
      });
  };

  const showUpdateModal = (round) => {
    setSelectedRound(round);
    setEditRoundName(round.roundName); // Cập nhật giá trị trường nhập liệu
    setUpdateId(round.id); // Cập nhật giá trị id
    setUpdateModalVisible(true);
  };

  const hideUpdateModal = () => {
    setSelectedRound(null);
    setUpdateModalVisible(false);
    setUpdateId(null); // Đặt lại updateId sau khi đóng modal
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
            <Button title="Update" onPress={() => showUpdateModal(item)} />
            <Button title="Delete" onPress={() => deleteRound(item.id)} />
          </View>
        )}
      />
      <Button title="Create Round" onPress={toggleModal} />
      <Button title="TournamentList" onPress={() => navigation.navigate('TournamentList')} />

      <Modal isVisible={isModalVisible}>
        <View style={styles.modalContainer}>
          <View style={styles.modalContent}>
            <Text style={styles.modalTitle}>Create Round</Text>
            <TextInput
              placeholder="Round Name"
              value={newRoundName}
              onChangeText={(text) => setNewRoundName(text)}
              style={styles.input}
            />
            <Pressable onPress={createRound}>
              <Text style={styles.buttonText}>Create Round</Text>
            </Pressable>
            <Pressable onPress={toggleModal}>
              <Text style={styles.buttonText}>Cancel</Text>
            </Pressable>
          </View>
        </View>
      </Modal>

      <Modal isVisible={isUpdateModalVisible}>
        <View style={styles.modalContainer}>
          <View style={styles.modalContent}>
            <Text style={styles.modalTitle}>Update Round</Text>
            {selectedRound && (
              <>
                <TextInput
                  placeholder="Round Name"
                  value={editRoundName}
                  onChangeText={(text) => setEditRoundName(text)}
                  style={styles.input}
                />
                <Pressable onPress={updateRound}>
                  <Text style={styles.buttonText}>Update Round</Text>
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
  roundContainer: {
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

export default Round;
