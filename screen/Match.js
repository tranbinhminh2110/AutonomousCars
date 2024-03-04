import React, { useState, useEffect } from 'react';
import { View, Text, FlatList, Button, TextInput, Pressable, StyleSheet} from 'react-native';
import Modal from 'react-native-modal';
import { LinearGradient } from 'expo-linear-gradient';
import { Picker } from '@react-native-picker/picker';

const Match = ({ navigation }) => {
  const [matches, setMatches] = useState([]);
  const [newMatchKeyId, setNewMatchKeyId] = useState('');
  const [selectedMap, setSelectedMap] = useState('');
  const [selectedRound, setSelectedRound] = useState('');
  const [selectedTournament, setSelectedTournament] = useState('');
  const [maps, setMaps] = useState([]);
  const [rounds, setRounds] = useState([]);
  const [tournaments, setTournaments] = useState([]);
  const [isModalVisible, setModalVisible] = useState(false);
  const [selectedMatch, setSelectedMatch] = useState(null);
  const [isUpdateModalVisible, setUpdateModalVisible] = useState(false);
  const [editMatchKeyId, setEditMatchKeyId] = useState('');
  const [updateId, setUpdateId] = useState(null);

  useEffect(() => {
    fetchMatches();
    fetchMaps();
    fetchRounds();
    fetchTournaments();
  }, []);

  const fetchMatches = () => {
    fetch('https://fptbottournamentweb.azurewebsites.net/api/match/get-all')
      .then(response => response.json())
      .then(data => {
        setMatches(data);
      })
      .catch(error => {
        console.error(error);
      });
  };

  const fetchMaps = () => {
    fetch('https://fptbottournamentweb.azurewebsites.net/api/map/get-all')
      .then(response => response.json())
      .then(data => {
        setMaps(data);
      })
      .catch(error => {
        console.error(error);
      });
  };

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

  const toggleModal = () => {
    setModalVisible(!isModalVisible);
  };

  const createMatch = () => {
    fetch('https://fptbottournamentweb.azurewebsites.net/api/match/create', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        keyId: newMatchKeyId,
        mapId: selectedMap,
        roundId: selectedRound,
        tournamentId: selectedTournament
      }),
    })
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        fetchMatches();
        fetchMaps();
        fetchRounds();
        fetchTournaments();
        setNewMatchKeyId('');
        setSelectedMap('');
        setSelectedRound('');
        setSelectedTournament('');
        toggleModal();
      })
      .catch(error => {
        console.error(error);
      });
  };

  const updateMatch = () => {
    fetch(`https://fptbottournamentweb.azurewebsites.net/api/Match/update-match/${updateId}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        keyId: editMatchKeyId || selectedMatch.keyId,
        mapId: selectedMap || selectedMatch.mapResponseModel.id,
        roundId: selectedRound || selectedMatch.roundResponseModel.id,
        tournamentId: selectedTournament || selectedMatch.tournamentResponseModel.id
      }),
    })
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        fetchMatches();
        fetchMaps();
        fetchRounds();
        fetchTournaments();
        hideUpdateModal();
      })
      .catch(error => {
        console.error(error);
      });
  };

  const deleteMatch = (id) => {
    fetch(`https://fptbottournamentweb.azurewebsites.net/api/match/delete/${id}`, {
      method: 'DELETE',
    })
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        fetchMatches();
      })
      .catch(error => {
        console.error(error);
      });
  };

  const showUpdateModal = (match) => {
    setSelectedMatch(match);
    setEditMatchKeyId(match.keyId);
    setSelectedMap(match.mapResponseModel.id);
    setSelectedRound(match.roundResponseModel.id);
    setSelectedTournament(match.tournamentResponseModel.id);
    setUpdateId(match.id);
    setUpdateModalVisible(true);
  };

  const hideUpdateModal = () => {
    setSelectedMatch(null);
    setUpdateModalVisible(false);
    setUpdateId(null);
  };

  return (
    <LinearGradient
      colors={['#FF9BD2', '#F4F27E']}
      style={styles.gradientContainer}
    >
      <Text style={styles.titleText}>Match</Text>

      <FlatList
        data={matches}
        keyExtractor={(item) => item.id.toString()}
        renderItem={({ item }) => (
          <View style={styles.matchContainer}>
            <Text>Key Id: {item.keyId}</Text>
            <Text>Map Name: {item.mapResponseModel.mapName}</Text>
            <Text>Round Name: {item.roundResponseModel.roundName}</Text>
            <Text>Tournament Name: {item.tournamentResponseModel.tournamentName}</Text>
            <Button title="Update" onPress={() => showUpdateModal(item)} />
            <Button title="Delete" onPress={() => deleteMatch(item.id)} />
          </View>
        )}
      />
      <Button title="Create Match" onPress={toggleModal} />
      <Button title="TournamentList" onPress={() => navigation.navigate('TournamentList')} />

      <Modal isVisible={isModalVisible}>
        <View style={styles.modalContainer}>
          <View style={styles.modalContent}>
            <Text style={styles.modalTitle}>Create Match</Text>
            <TextInput
              placeholder="Key Id"
              value={newMatchKeyId}
              onChangeText={(text) => setNewMatchKeyId(text)}
              style={styles.input}
            />
            <Picker
              selectedValue={selectedMap}
              style={{ height: 50, width: 150 }}
              onValueChange={(itemValue, itemIndex) => setSelectedMap(itemValue)}
            >
              <Picker.Item label="Select Map" value="" />
              {maps.map(map => (
                <Picker.Item key={map.id} label={map.mapName} value={map.id} />
              ))}
            </Picker>

            <Picker
              selectedValue={selectedRound}
              style={{ height: 50, width: 150 }}
              onValueChange={(itemValue, itemIndex) => setSelectedRound(itemValue)}
            >
              <Picker.Item label="Select Round" value="" />
              {rounds.map(round => (
                <Picker.Item key={round.id} label={round.roundName} value={round.id} />
              ))}
            </Picker>

            <Picker
              selectedValue={selectedTournament}
              style={{ height: 50, width: 150 }}
              onValueChange={(itemValue, itemIndex) => setSelectedTournament(itemValue)}
            >
              <Picker.Item label="Select Tournament" value="" />
              {tournaments.map(tournament => (
                <Picker.Item key={tournament.id} label={tournament.tournamentName} value={tournament.id} />
              ))}
            </Picker>
            <Pressable onPress={createMatch}>
              <Text style={styles.buttonText}>Create Match</Text>
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
            <Text style={styles.modalTitle}>Update Match</Text>
            {selectedMatch && (
              <>
                <TextInput
                  placeholder="Key Id"
                  value={editMatchKeyId}
                  onChangeText={(text) => setEditMatchKeyId(text)}
                  style={styles.input}
                />
                <Picker
                  selectedValue={selectedMap}
                  style={{ height: 50, width: 150 }}
                  onValueChange={(itemValue, itemIndex) => setSelectedMap(itemValue)}
                >
                  {maps.map(map => (
                    <Picker.Item key={map.id} label={map.mapName} value={map.id} />
                  ))}
                </Picker>
                <Picker
                  selectedValue={selectedRound}
                  style={{ height: 50, width: 150 }}
                  onValueChange={(itemValue, itemIndex) => setSelectedRound(itemValue)}
                >
                  {rounds.map(round => (
                    <Picker.Item key={round.id} label={round.roundName} value={round.id} />
                  ))}
                </Picker>
                <Picker
                  selectedValue={selectedTournament}
                  style={{ height: 50, width: 150 }}
                  onValueChange={(itemValue, itemIndex) => setSelectedTournament(itemValue)}
                >
                  {tournaments.map(tournament => (
                    <Picker.Item key={tournament.id} label={tournament.tournamentName} value={tournament.id} />
                  ))}
                </Picker>
                <Pressable onPress={updateMatch}>
                  <Text style={styles.buttonText}>Update Match</Text>
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
  matchContainer: {
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

export default Match;
