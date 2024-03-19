import React, { useEffect, useState } from 'react';
import { View, Text, FlatList, TouchableOpacity, StyleSheet, Modal, Button, TextInput } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { Ionicons } from '@expo/vector-icons';
import RNPickerSelect from 'react-native-picker-select';
import DateTimePickerModal from 'react-native-modal-datetime-picker';

const TeamActivity = ({ navigation, route }) => {
  const [teamActivities, setTeamActivities] = useState([]);
  const { teamInMatchId } = route.params;
  const [isMenuOpen, setIsMenuOpen] = useState(false);
  const [timerRunning, setTimerRunning] = useState(false);
  const [elapsedTime, setElapsedTime] = useState(0);
  const [timerIntervalId, setTimerIntervalId] = useState(null);
  const [filteredTeamActivities, setFilteredTeamActivities] = useState([]);
  const [activityDescription, setActivityDescription] = useState('');
  const [activityTypeId, setActivityTypeId] = useState('');
  const [score, setScore] = useState('');
  const [violation, setViolation] = useState('');
  const [isLogModalOpen, setIsLogModalOpen] = useState(false);
  const [activityTypeOptions, setActivityTypeOptions] = useState([]);
  const [isStartTimePickerVisible, setIsStartTimePickerVisible] = useState(false);
  const [isEndTimePickerVisible, setIsEndTimePickerVisible] = useState(false);
  const [startTime, setStartTime] = useState(new Date());
  const [endTime, setEndTime] = useState(new Date());
  const [duration, setDuration] = useState('00:00:00');
  const [isActivityTypePickerVisible, setIsActivityTypePickerVisible] = useState(false);
  const [selectedActivityTypeId, setSelectedActivityTypeId] = useState(null);
  const [isModalVisible, setIsModalVisible] = useState(true);
  const [currentPage, setCurrentPage] = useState(1);
  const [itemsPerPage] = useState(4); // Số lượng activityTypeId mỗi trang


  useEffect(() => {
    // Sử dụng teamInMatchId từ route.params
    fetchTeamActivities();
  }, [route.params.teamInMatchId, isLogModalOpen]);

  useEffect(() => {
    fetchActivityTypes();
  }, []);

  useEffect(() => {
      setFilteredTeamActivities(
        teamActivities.filter(activity => activity.teamInMatchId === teamInMatchId)
          .sort((a, b) => new Date(b.startTime) - new Date(a.startTime))
      );
  }, [teamActivities]);

  const fetchTeamActivities = () => {
    fetch('https://fptbottournamentweb.azurewebsites.net/api/team-activity/get-all-activity')
      .then(response => response.json())
      .then(data => {
        setTeamActivities(data);
      })
      .catch(error => {
        console.error(error);
      });
  };

  const fetchActivityTypes = () => {
    fetch('https://fptbottournamentweb.azurewebsites.net/api/activity-type/get-all')
      .then(response => response.json())
      .then(data => {
        const options = data.map(activity => ({
          label: activity.typeName.toString(),
          value: activity.id.toString(), // Chuyển id thành chuỗi để tránh vấn đề về kiểu dữ liệu
        }));
        setActivityTypeOptions(options);
        if (options.length > 0) {
          setSelectedActivityTypeId(options[0].value); // Cập nhật giá trị mặc định cho selectedActivityTypeId
        }
      })
      .catch(error => {
        console.error(error);
      });
  };

  const handleStartTimer = () => {
    setTimerRunning(true);
    const startTime = Date.now() - elapsedTime;
    const intervalId = setInterval(() => {
      const now = Date.now();
      const elapsed = now - startTime;
      setElapsedTime(elapsed);
    }, 1000);
    setTimerIntervalId(intervalId);
  };

  const handleStopTimer = () => {
    setTimerRunning(false);
    clearInterval(timerIntervalId);
  };

  const handleResetTimer = () => {
    setTimerRunning(false);
    setElapsedTime(0);
    clearInterval(timerIntervalId);
  };

  const handleHamburgerPress = () => {
    setIsMenuOpen(!isMenuOpen);
  };

  const handleProfilePress = () => {
    navigation.navigate('Profile');
  };

  const handleMenuPress = (screen) => {
    navigation.navigate(screen);
    setIsMenuOpen(false);
  };

  const formatTime = (time) => {
    const minutes = Math.floor(time / 60000);
    const seconds = ((time % 60000) / 1000).toFixed(0);
    return `${minutes < 10 ? '0' : ''}${minutes}:${seconds < 10 ? '0' : ''}${seconds}`;
  };

  const handleLogButtonPress = () => {
    setIsLogModalOpen(true);
  };

  const handleLogActivity = () => {
    const numericScore = parseFloat(score);

    fetch('https://fptbottournamentweb.azurewebsites.net/api/team-activity/create', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        description: activityDescription,
        activityTypeId: selectedActivityTypeId,
        teamInMatchId: teamInMatchId,
        startTime: startTime.toISOString(),
        endTime: endTime.toISOString(),
        duration: duration,
        score: numericScore,
        violation: parseInt(violation),
      }),
    })
      .then(response => {
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        return response.json();
      })
      .then(data => {
        // Log activity successfully
        console.log('Log activity successfully:', data);

        // Fetch team activities to reload the data
        fetchTeamActivities();

        // Reset input fields
        setActivityDescription('');
        setScore('');
        setViolation('');
        setSelectedActivityTypeId('');
        setStartTime(new Date());
        setEndTime(new Date());
        setDuration('00:00:00');
      })
      .catch(() => {
        // Đóng modal sau khi gặp lỗi
        setIsLogModalOpen(false);
      });
  };



  const handleConfirmStartTime = (date) => {
    setStartTime(date);
    setIsStartTimePickerVisible(false);
  };

  const handleConfirmEndTime = (date) => {
    setEndTime(date);
    setIsEndTimePickerVisible(false);
  };

  const handleDurationChange = (text) => {
    setDuration(text);
  };
  const goToPreviousPage = () => {
    setCurrentPage(prevPage => prevPage - 1);
  };

  const goToNextPage = () => {
    setCurrentPage(prevPage => prevPage + 1);
  };
  const indexOfLastItem = currentPage * itemsPerPage;
  const indexOfFirstItem = indexOfLastItem - itemsPerPage;
  const currentItems = activityTypeOptions.slice(indexOfFirstItem, indexOfLastItem);


  return (
    <LinearGradient
      colors={['#7FC7D9', '#E9F6FF']}
      style={styles.gradientContainer}
    >
      {/* Header */}
      <View style={styles.header}>
        <TouchableOpacity onPress={handleHamburgerPress}>
          <Ionicons name={isMenuOpen ? 'ios-close' : 'ios-menu'} size={32} color="white" />
        </TouchableOpacity>
        <Text style={styles.titleText}>Team Activities</Text>
        <TouchableOpacity onPress={handleProfilePress}>
          <Ionicons name="ios-person" size={32} color="white" />
        </TouchableOpacity>
      </View>

      {/* Hamburger Menu */}
      {isMenuOpen && (
        <View style={styles.menu}>
          <TouchableOpacity onPress={() => handleMenuPress('Map')}>
            <Text style={styles.menuItem}>MAP</Text>
          </TouchableOpacity>
          <TouchableOpacity onPress={() => handleMenuPress('HighSchool')}>
            <Text style={styles.menuItem}>HIGHSCHOOL</Text>
          </TouchableOpacity>
          <TouchableOpacity onPress={() => handleMenuPress('ActivityType')}>
            <Text style={styles.menuItem}>ACTIVITYTYPE</Text>
          </TouchableOpacity>
          <TouchableOpacity onPress={() => handleMenuPress('Round')}>
            <Text style={styles.menuItem}>ROUND</Text>
          </TouchableOpacity>
          <TouchableOpacity onPress={() => handleMenuPress('TournamentList')}>
            <Text style={styles.menuItem}>TOURNAMENT</Text>
          </TouchableOpacity>
          <TouchableOpacity onPress={() => navigation.goBack()}>
            <Text style={styles.menuItem}>BACK</Text>
          </TouchableOpacity>
        </View>
      )}

      {/* Timer */}
      <View style={styles.timerContainer}>
        <Text style={styles.timerText}>{formatTime(elapsedTime)}</Text>
      </View>

      {/* Start, Stop, Reset, and Log Activity buttons */}
      <View style={styles.buttonContainer}>
        <TouchableOpacity style={styles.startButton} onPress={handleStartTimer} disabled={timerRunning}>
          <Text style={styles.buttonText}>START</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.stopButton} onPress={handleStopTimer} disabled={!timerRunning}>
          <Text style={styles.buttonText}>STOP</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.resetButton} onPress={handleResetTimer}>
          <Text style={styles.buttonText}>RESET</Text>
        </TouchableOpacity>
      </View>
      <View style={styles.logButtonContainer}>
        <TouchableOpacity style={styles.logButton} onPress={handleLogButtonPress}>
          <Text style={styles.buttonText}>LOG ACTIVITY</Text>
        </TouchableOpacity>
      </View>

      {/* Modal for Log Activity */}
            <Modal visible={isLogModalOpen} animationType="slide">
              <View style={styles.modalContainer}>
                <Text style={styles.modalTitle}>Log Activity</Text>

                <View style={styles.paginationContainer}>
                  <TouchableOpacity onPress={goToPreviousPage} disabled={currentPage === 1}>
                    <Text style={styles.paginationButton}>Previous </Text>
                  </TouchableOpacity>
                  <Text style={styles.paginationText}>
                    Page {currentPage} of {Math.ceil(activityTypeOptions.length / itemsPerPage)}
                  </Text>
                  <TouchableOpacity onPress={goToNextPage} disabled={indexOfLastItem >= activityTypeOptions.length}>
                    <Text style={styles.paginationButton}> Next</Text>
                  </TouchableOpacity>
                </View>

                {/* Activity Type selection */}
                <View style={styles.activityTypeContainer}>
                  {currentItems.map(option => (
                    <TouchableOpacity
                      key={option.value}
                      style={[
                        styles.activityTypeButton,
                        option.value === selectedActivityTypeId && styles.activityTypeButtonSelected
                      ]}
                      onPress={() => setSelectedActivityTypeId(option.value)}
                    >
                      <Text style={styles.activityTypeButtonText}>{option.label}</Text>
                    </TouchableOpacity>
                  ))}
                </View>


                {/* Other input fields */}
                <TextInput
                  style={styles.input}
                  placeholder="Activity Description"
                  onChangeText={setActivityDescription}
                  value={activityDescription}
                />
                {/* Start Time */}
                <TouchableOpacity style={styles.input} onPress={() => setIsStartTimePickerVisible(true)}>
                  <Text>{startTime.toLocaleString()}</Text>
                </TouchableOpacity>
                {/* End Time */}
                <TouchableOpacity style={styles.input} onPress={() => setIsEndTimePickerVisible(true)}>
                  <Text>{endTime.toLocaleString()}</Text>
                </TouchableOpacity>
                {/* Duration TextInput */}
                <TextInput
                  style={styles.input}
                  placeholder="Duration (HH:mm:ss)"
                  onChangeText={handleDurationChange}
                  value={duration}
                  keyboardType="numeric"
                />
                {/* Score */}
                <TextInput
                  style={styles.input}
                  placeholder="Score"
                  onChangeText={setScore}
                  value={score}
                  keyboardType="numeric"
                />
                {/* Violation */}
                <TextInput
                  style={styles.input}
                  placeholder="Violation"
                  onChangeText={setViolation}
                  value={violation}
                  keyboardType="numeric"
                />
                {/* Log and cancel buttons */}
                <View style={styles.modalButtonContainer}>
                  <Button title="Cancel" onPress={() => setIsLogModalOpen(false)} />
                  <Button title="Log" onPress={handleLogActivity} />
                </View>
              </View>
            </Modal>

            {/* DateTimePicker for Start Time */}
            <DateTimePickerModal
              isVisible={isStartTimePickerVisible}
              mode="datetime"
              onConfirm={handleConfirmStartTime}
              onCancel={() => setIsStartTimePickerVisible(false)}
            />

            {/* DateTimePicker for End Time */}
            <DateTimePickerModal
              isVisible={isEndTimePickerVisible}
              mode="datetime"
              onConfirm={handleConfirmEndTime}
              onCancel={() => setIsEndTimePickerVisible(false)}
            />

      {/* List of team activities */}
      <FlatList
        data={filteredTeamActivities}
        keyExtractor={(item) => item.id.toString()}
        renderItem={({ item }) => (
          <View style={styles.activityContainer}>
            <Text>Activity Type: {item.activityTypeName}</Text>
            <Text>Description: {item.description}</Text>
            <Text>Start Time: {item.startTime}</Text>
            <Text>End Time: {item.endTime}</Text>
            <Text>Duration: {item.duration}</Text>
            <Text>Score: {item.score}</Text>
            <Text>Violation: {item.violation}</Text>
          </View>
        )}
      />
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
  activityContainer: {
    backgroundColor: 'white',
    padding: 16,
    marginBottom: 16,
    borderRadius: 8,
  },
  header: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    marginBottom: 16,
  },
  menu: {
    backgroundColor: 'rgba(255, 255, 255, 0.9)',
    position: 'absolute',
    top: 60,
    left: 0,
    width: 250,
    borderRadius: 8,
    paddingVertical: 20,
    paddingHorizontal: 12,
    zIndex: 1,
  },
  menuItem: {
    fontSize: 18,
    fontWeight: 'bold',
    marginBottom: 8,
  },
  timerContainer: {
    alignItems: 'center',
    marginBottom: 16,
  },
  timerText: {
    fontSize: 24,
    fontWeight: 'bold',
  },
  buttonContainer: {
    flexDirection: 'row',
    justifyContent: 'space-around',
    marginBottom: 16,
  },
  logButtonContainer: {
    alignItems: 'center',
    marginBottom: 16,
  },
  startButton: {
    backgroundColor: '#01D116',
    padding: 16,
    borderRadius: 8,
  },
  stopButton: {
    backgroundColor: '#E50808',
    padding: 16,
    borderRadius: 8,
  },
  resetButton: {
    backgroundColor: '#D9D9D9',
    padding: 16,
    borderRadius: 8,
  },
  logButton: {
    backgroundColor: '#17C2F8',
    padding: 16,
    borderRadius: 8,
    alignItems: 'center',
    marginBottom: 16,
  },
  buttonText: {
    color: 'black',
    fontSize: 18,
    fontWeight: 'bold',
  },
  modalContainer: {
    backgroundColor: '#EEEEEE',
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
  modalTitle: {
    fontSize: 24,
    fontWeight: 'bold',
    marginBottom: 16,
  },
  input: {
    width: '80%',
    height: 40,
    borderColor: 'gray',
    borderWidth: 1,
    marginBottom: 16,
    paddingHorizontal: 8,
  },
  modalButtonContainer: {
    flexDirection: 'row',
    justifyContent: 'space-around',
    width: '80%',
  },
    activityTypeContainer: {
      flexDirection: 'row',
      justifyContent: 'space-between',
      marginBottom: 16,
    },
    activityTypeButton: {
      backgroundColor: '#17C2F8',
      paddingVertical: 12,
      paddingHorizontal: 20,
      borderRadius: 8,
    },
    activityTypeButtonText: {
      fontSize: 16,
      fontWeight: 'bold',
      color: 'white',
    },
    activityTypeButtonSelected: {
      backgroundColor: '#0C5DA5',
    },
    teamInMatchIdContainer: {
      alignItems: 'center',
      marginBottom: 16,
    },
    paginationContainer: {
      flexDirection: 'row',
      justifyContent: 'center', // Căn giữa các phần tử theo chiều ngang
      alignItems: 'center',
      marginBottom: 16,
    },
    paginationText: {
      fontSize: 16,
      fontWeight: 'bold',
      color: '#333', // Màu chữ đậm
    },
    paginationButton: {
      fontSize: 16,
      color: '#0C5DA5', // Màu của nút
    },
});

export default TeamActivity;
