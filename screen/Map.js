import React, { useEffect, useState } from 'react';
import { View, Text, FlatList, Button, TextInput, Pressable, ScrollView, StyleSheet } from 'react-native';
import Modal from 'react-native-modal';
import DateTimePickerModal from 'react-native-modal-datetime-picker';
import { LinearGradient } from 'expo-linear-gradient';

const Map = ({ navigation }) => {
  const [maps, setMaps] = useState([]);
  const [newKeyId, setNewKeyId] = useState('');
  const [newMapName, setNewMapName] = useState('');
  const [isModalVisible, setModalVisible] = useState(false);
  const [selectedMap, setSelectedMap] = useState(null);
  const [isUpdateModalVisible, setUpdateModalVisible] = useState(false);

  useEffect(() => {
    fetchMaps();
  }, []);

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

  const toggleModal = () => {
    setModalVisible(!isModalVisible);
  };

  const createMap = () => {
    fetch('https://fptbottournamentweb.azurewebsites.net/api/map/create', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        keyId: newKeyId || Math.floor(Math.random() * 1000),
        mapName: newMapName,
      }),
    })
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        fetchMaps();
        setNewKeyId('');
        setNewMapName('');
        toggleModal();
      })
      .catch(error => {
        console.error(error);
      });
  };

  const updateMap = () => {
    const { id, keyId, mapName } = selectedMap;

    fetch(`https://fptbottournamentweb.azurewebsites.net/api/map/update/${id}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        keyId,
        mapName,
      }),
    })
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        fetchMaps();
        hideUpdateModal();
      })
      .catch(error => {
        console.error(error);
      });
  };

  const deleteMap = (id) => {
    fetch(`https://fptbottournamentweb.azurewebsites.net/api/map/delete/${id}`, {
      method: 'DELETE',
    })
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        fetchMaps();
      })
      .catch(error => {
        console.error(error);
      });
  };

  const showUpdateModal = (map) => {
    setSelectedMap(map);
    setUpdateModalVisible(true);
  };

  const hideUpdateModal = () => {
    setSelectedMap(null);
    setUpdateModalVisible(false);
  };

  return (
    <LinearGradient
      colors={['#9F8CE3', '#FFBE98']}
      style={styles.gradientContainer}
    >
      <Text style={styles.titleText}>Maps</Text>

      <FlatList
        data={maps}
        keyExtractor={(item) => item.id.toString()}
        renderItem={({ item }) => (
          <View style={styles.mapContainer}>
            <Text>Map Name: {item.mapName}</Text>
            <Text>Key ID: {item.keyId}</Text>
            <Button title="Update" onPress={() => showUpdateModal(item)} />
            <Button title="Delete" onPress={() => deleteMap(item.id)} />
          </View>
        )}
      />
      <Button title="Create Map" onPress={toggleModal} />
      <Button title="Tournament List" onPress={() => navigation.navigate('TournamentList')} />

<Modal isVisible={isModalVisible}>
  <ScrollView contentContainerStyle={styles.modalContainer}>
    <View style={styles.modalContent}>
      <Text style={styles.modalTitle}>Create Map</Text>
      <TextInput
        placeholder="Key ID"
        value={newKeyId}
        onChangeText={(text) => setNewKeyId(text)}
        style={styles.input}
      />
      <TextInput
        placeholder="Map Name"
        value={newMapName}
        onChangeText={(text) => setNewMapName(text)}
        style={styles.input}
      />
      <Pressable onPress={createMap}>
        <Text style={styles.buttonText}>Create Map</Text>
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
      <Text style={styles.modalTitle}>Update Map</Text>
      {selectedMap && (
        <>
          <TextInput
            placeholder="Key ID"
            value={selectedMap.keyId.toString()}
            onChangeText={(text) => setSelectedMap({ ...selectedMap, keyId: text })}
            style={styles.input}
            placeholderTextColor="black"
          />
          <TextInput
            placeholder="Map Name"
            value={selectedMap.mapName}
            onChangeText={(text) => setSelectedMap({ ...selectedMap, mapName: text })}
            style={styles.input}
            placeholderTextColor="black"
          />
          <Pressable onPress={updateMap}>
            <Text style={styles.buttonText}>Update Map</Text>
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
  mapContainer: {
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

export default Map;
