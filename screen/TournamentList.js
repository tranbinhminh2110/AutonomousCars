import React, { useEffect, useState } from 'react';
import { View, Text, FlatList, Button, TextInput, Pressable, ScrollView, StyleSheet } from 'react-native';
import Modal from 'react-native-modal';
import DateTimePickerModal from 'react-native-modal-datetime-picker';
import { LinearGradient } from 'expo-linear-gradient';

const TournamentList = ({ navigation }) => {
  const [tournaments, setTournaments] = useState([]);
  const [newKeyId, setNewKeyId] = useState('');
  const [newTournamentName, setNewTournamentName] = useState('');
  const [newStartDate, setNewStartDate] = useState('');
  const [newEndDate, setNewEndDate] = useState('');
  const [isModalVisible, setModalVisible] = useState(false);
  const [isStartDatePickerVisible, setStartDatePickerVisible] = useState(false);
  const [isEndDatePickerVisible, setEndDatePickerVisible] = useState(false);

  const [selectedTournament, setSelectedTournament] = useState(null);
  const [isUpdateModalVisible, setUpdateModalVisible] = useState(false);

  useEffect(() => {
    fetchTournaments();
  }, []);

  const fetchTournaments = () => {
    fetch('https://fptbottournamentweb.azurewebsites.net/api/Tournament/get-all-tournaments')
      .then(response => response.json())
      .then(data => {
        setTournaments(data);
      })
      .catch(error => {
        console.error(error);
      });
  };

  const toggleModal = () => {
    setModalVisible(!isModalVisible);
  };

  const showStartDatePicker = () => {
    setStartDatePickerVisible(true);
  };

  const hideStartDatePicker = () => {
    setStartDatePickerVisible(false);
  };

  const handleStartDateConfirm = (date) => {
    const formattedDate = new Date(date.getFullYear(), date.getMonth(), date.getDate());
    setNewStartDate(formattedDate.toISOString());
    hideStartDatePicker();
  };

  const showEndDatePicker = () => {
    setEndDatePickerVisible(true);
  };

  const hideEndDatePicker = () => {
    setEndDatePickerVisible(false);
  };

  const handleEndDateConfirm = (date) => {
    const formattedDate = new Date(date.getFullYear(), date.getMonth(), date.getDate());
    setNewEndDate(formattedDate.toISOString());
    hideEndDatePicker();
  };

  const createTournament = () => {
    fetch('https://fptbottournamentweb.azurewebsites.net/api/Tournament/create-tournament', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        keyId: newKeyId || Math.floor(Math.random() * 1000),
        tournamentName: newTournamentName,
        startDate: newStartDate || new Date().toISOString(),
        endDate: newEndDate || new Date().toISOString(),
      }),
    })
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        fetchTournaments();
        setNewKeyId('');
        setNewTournamentName('');
        setNewStartDate('');
        setNewEndDate('');
        toggleModal();
      })
      .catch(error => {
        console.error(error);
      });
  };

  const updateTournament = () => {
    const { id, keyId, tournamentName, startDate, endDate } = selectedTournament;

    fetch(`https://fptbottournamentweb.azurewebsites.net/api/Tournament/update-tournament?id=${id}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        keyId,
        tournamentName,
        startDate: newStartDate || startDate,
        endDate: newEndDate || endDate,
      }),
    })
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        fetchTournaments();
        hideUpdateModal();
      })
      .catch(error => {
        console.error(error);
      });
  };

  const deleteTournament = (id) => {
    fetch(`https://fptbottournamentweb.azurewebsites.net/api/Tournament/delete-tournament?id=${id}`, {
      method: 'DELETE',
    })
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        fetchTournaments();
      })
      .catch(error => {
        console.error(error);
      });
  };

  const showUpdateModal = (tournament) => {
    setSelectedTournament(tournament);
    setUpdateModalVisible(true);
  };

  const hideUpdateModal = () => {
    setSelectedTournament(null);
    setUpdateModalVisible(false);
  };

  return (
    <LinearGradient
      colors={['#96E9C6', '#83C0C1']}
      style={styles.gradientContainer}
    >
      <Text style={styles.titleText}>Tournament</Text>

      <FlatList
        data={tournaments}
        keyExtractor={(item) => item.id.toString()}
        renderItem={({ item }) => (
          <View style={styles.tournamentContainer}>
            <Text>Tournament Name: {item.tournamentName}</Text>
            <Text>Key ID: {item.keyId}</Text>
            <Text>Start Date: {new Date(item.startDate).toLocaleDateString()}</Text>
            <Text>End Date: {new Date(item.endDate).toLocaleDateString()}</Text>
            <Button title="Update" onPress={() => showUpdateModal(item)} />
            <Button title="Delete" onPress={() => deleteTournament(item.id)} />
          </View>
        )}
      />
      <Button title="Create Tournament" onPress={toggleModal} />
      <Button title="Map" onPress={() => navigation.navigate('Map')} />

<Modal isVisible={isModalVisible}>
  <ScrollView contentContainerStyle={styles.modalContainer}>
    <View style={styles.modalContent}>
      <Text style={styles.modalTitle}>Create Tournament</Text>
      <TextInput
        placeholder="Key ID"
        value={newKeyId}
        onChangeText={(text) => setNewKeyId(text)}
        style={styles.input}
      />
      <TextInput
        placeholder="Tournament Name"
        value={newTournamentName}
        onChangeText={(text) => setNewTournamentName(text)}
        style={styles.input}
      />

      <Pressable onPress={showStartDatePicker}>
        <Text style={styles.buttonText}>Select Start Date</Text>
      </Pressable>

      {newStartDate && (
        <View>
          <Text style={styles.buttonText}>
            Selected Start Date: {new Date(newStartDate).toLocaleDateString()}
          </Text>
        </View>
      )}

      <Pressable onPress={showEndDatePicker}>
        <Text style={styles.buttonText}>Select End Date</Text>
      </Pressable>

      {newEndDate && (
        <View>
          <Text style={styles.buttonText}>
            Selected End Date: {new Date(newEndDate).toLocaleDateString()}
          </Text>
        </View>
      )}

      <Pressable onPress={createTournament}>
        <Text style={styles.buttonText}>Create Tournament</Text>
      </Pressable>
      <Pressable onPress={toggleModal}>
        <Text style={styles.buttonText}>Cancel</Text>
      </Pressable>

      <DateTimePickerModal
        isVisible={isStartDatePickerVisible}
        mode="date"
        onConfirm={handleStartDateConfirm}
        onCancel={hideStartDatePicker}
      />

      <DateTimePickerModal
        isVisible={isEndDatePickerVisible}
        mode="date"
        onConfirm={handleEndDateConfirm}
        onCancel={hideEndDatePicker}
      />
    </View>
  </ScrollView>
</Modal>

<Modal isVisible={isUpdateModalVisible}>
  <View style={styles.modalContainer}>
    <View style={styles.modalContent}>
      <Text style={styles.modalTitle}>Update Tournament</Text>
      {selectedTournament && (
        <>
          <TextInput
            placeholder="Key ID"
            value={selectedTournament.keyId.toString()}
            onChangeText={(text) => setSelectedTournament({ ...selectedTournament, keyId: text })}
            style={styles.input}
            placeholderTextColor="black"
          />
          <TextInput
            placeholder="Tournament Name"
            value={selectedTournament.tournamentName}
            onChangeText={(text) => setSelectedTournament({ ...selectedTournament, tournamentName: text })}
            style={styles.input}
            placeholderTextColor="black"
          />
          <Pressable onPress={showStartDatePicker}>
            <Text style={styles.buttonText}>Select Start Date</Text>
          </Pressable>
          {selectedTournament.startDate && (
            <View>
              <Text style={styles.buttonText}>
                Selected Start Date: {new Date(selectedTournament.startDate).toLocaleDateString()}
              </Text>
            </View>
          )}
          <Pressable onPress={showEndDatePicker}>
            <Text style={styles.buttonText}>Select End Date</Text>
          </Pressable>
          {selectedTournament.endDate && (
            <View>
              <Text style={styles.buttonText}>
                Selected End Date: {new Date(selectedTournament.endDate).toLocaleDateString()}
              </Text>
            </View>
          )}
          <Pressable onPress={updateTournament}>
            <Text style={styles.buttonText}>Update Tournament</Text>
          </Pressable>
          <Pressable onPress={hideUpdateModal}>
            <Text style={styles.buttonText}>Cancel</Text>
          </Pressable>

          <DateTimePickerModal
            isVisible={isStartDatePickerVisible}
            mode="date"
            date={new Date(selectedTournament.startDate)}
            onConfirm={(date) => {
              const formattedDate = new Date(date.getFullYear(), date.getMonth(), date.getDate());
              setSelectedTournament({ ...selectedTournament, startDate: formattedDate.toISOString() });
              hideStartDatePicker();
            }}
            onCancel={hideStartDatePicker}
          />

          <DateTimePickerModal
            isVisible={isEndDatePickerVisible}
            mode="date"
            date={new Date(selectedTournament.endDate)}
            onConfirm={(date) => {
              const formattedDate = new Date(date.getFullYear(), date.getMonth(), date.getDate());
              setSelectedTournament({ ...selectedTournament, endDate: formattedDate.toISOString() });
              hideEndDatePicker();
            }}
            onCancel={hideEndDatePicker}
          />
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
  tournamentContainer: {
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

export default TournamentList;
