import React, { useState, useEffect } from 'react';
import { View, Text, FlatList, Button, TextInput, Pressable, StyleSheet } from 'react-native';
import Modal from 'react-native-modal';
import { LinearGradient } from 'expo-linear-gradient';

const ActivityType = ({ navigation }) => {
  const [activityTypes, setActivityTypes] = useState([]);
  const [newTypeName, setNewTypeName] = useState('');
  const [isModalVisible, setModalVisible] = useState(false);
  const [selectedActivityType, setSelectedActivityType] = useState(null);
  const [isUpdateModalVisible, setUpdateModalVisible] = useState(false);
  const [editTypeName, setEditTypeName] = useState('');
  const [updateId, setUpdateId] = useState(null); // Thêm state updateId

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

  const toggleModal = () => {
    setModalVisible(!isModalVisible);
  };

  const createActivityType = () => {
    fetch('https://fptbottournamentweb.azurewebsites.net/api/activity-type/create', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        typeName: newTypeName,
      }),
    })
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        fetchActivityTypes();
        setNewTypeName('');
        toggleModal();
      })
      .catch(error => {
        console.error(error);
      });
  };

  const updateActivityType = () => {
    fetch(`https://fptbottournamentweb.azurewebsites.net/api/activity-type/update/${updateId}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        typeName: editTypeName || selectedActivityType.typeName,
      }),
    })
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        fetchActivityTypes();
        hideUpdateModal();
      })
      .catch(error => {
        console.error(error);
      });
  };

  const deleteActivityType = (id) => {
    fetch(`https://fptbottournamentweb.azurewebsites.net/api/activity-type/delete/${id}`, {
      method: 'DELETE',
    })
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        fetchActivityTypes();
      })
      .catch(error => {
        console.error(error);
      });
  };

  const showUpdateModal = (activityType) => {
    setSelectedActivityType(activityType);
    setEditTypeName(activityType.typeName); // Cập nhật giá trị trường nhập liệu
    setUpdateId(activityType.id); // Cập nhật giá trị id
    setUpdateModalVisible(true);
  };

  const hideUpdateModal = () => {
    setSelectedActivityType(null);
    setUpdateModalVisible(false);
    setUpdateId(null); // Đặt lại updateId sau khi đóng modal
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
            <Button title="Update" onPress={() => showUpdateModal(item)} />
            <Button title="Delete" onPress={() => deleteActivityType(item.id)} />
          </View>
        )}
      />
      <Button title="Create Activity Type" onPress={toggleModal} />
      <Button title="TournamentList" onPress={() => navigation.navigate('TournamentList')} />

      <Modal isVisible={isModalVisible}>
        <View style={styles.modalContainer}>
          <View style={styles.modalContent}>
            <Text style={styles.modalTitle}>Create Activity Type</Text>
            <TextInput
              placeholder="Type Name"
              value={newTypeName}
              onChangeText={(text) => setNewTypeName(text)}
              style={styles.input}
            />
            <Pressable onPress={createActivityType}>
              <Text style={styles.buttonText}>Create Activity Type</Text>
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
            <Text style={styles.modalTitle}>Update Activity Type</Text>
            {selectedActivityType && (
              <>
                <TextInput
                  placeholder="Type Name"
                  value={editTypeName}
                  onChangeText={(text) => setEditTypeName(text)}
                  style={styles.input}
                />
                <Pressable onPress={updateActivityType}>
                  <Text style={styles.buttonText}>Update Activity Type</Text>
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
  activityTypeContainer: {
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

export default ActivityType;
