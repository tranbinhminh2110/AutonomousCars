import React, { useState } from "react";
import {
  View,
  Text,
  Image,
  Pressable,
  TextInput,
  TouchableOpacity,
  Alert,
} from "react-native";
import { SafeAreaView } from "react-native-safe-area-context";
import { Ionicons } from "@expo/vector-icons";
import Checkbox from "expo-checkbox";
import COLORS from "../constants/colors";
import Button from "../components/Button";
import { useNavigation } from '@react-navigation/native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { useDispatch } from 'react-redux';
import { setToken } from '../StorageToken/actions';

const Login = ({ navigation }) => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [isPasswordShown, setIsPasswordShown] = useState(false);
  const [isChecked, setIsChecked] = useState(false);
  const dispatch = useDispatch();
  const [temporaryUserInfo, setTemporaryUserInfo] = useState('');

  const _userLogin = () => {
    if (email === '' || password === '') {
      alert('Invalid email or password');
    } else {
      fetch('https://fptbottournamentmanagement-2e9b0b503b66.herokuapp.com/api/Login/login', {
        method: "POST",
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          username: email,
          password: password
        })
      })
      .then((response) => {
        if (!response.ok) {
          throw new Error('Invalid email or password');
        }
        return response.json();
      })
      .then((responseData) => {
        setTemporaryUserInfo({
          userName: responseData.userName,
          userEmail: responseData.userEmail,
          fullName: responseData.fullName
        });

        // Lưu thông tin người dùng vào AsyncStorage
        AsyncStorage.setItem('temporaryUserInfo', JSON.stringify({
          userName: responseData.userName,
          userEmail: responseData.userEmail,
          fullName: responseData.fullName,
        }));

        AsyncStorage.setItem('token', responseData.token);
        dispatch(setToken(responseData.token));
        navigation.navigate('TournamentList');
      })
      .catch((error) => {
        console.error('Error:', error);
        alert(error.message || 'An error occurred');
      });
    }
  };

  return (
    <SafeAreaView style={{ flex: 1, backgroundColor: COLORS.white }}>
      <View style={{ flex: 1, marginHorizontal: 22 }}>
        <View style={{ marginVertical: 22 }}>
          <Text
            style={{
              fontSize: 22,
              fontWeight: "bold",
              marginVertical: 12,
              color: COLORS.black,
            }}
          >
            Hi Welcome Back ! 👋
          </Text>
        </View>

        <View style={{ marginBottom: 12 }}>
          <Text
            style={{
              fontSize: 16,
              fontWeight: 400,
              marginVertical: 8,
            }}
          >
            Email address
          </Text>

          <View
            style={{
              width: "100%",
              height: 48,
              borderColor: COLORS.black,
              borderWidth: 1,
              borderRadius: 8,
              alignItems: "center",
              justifyContent: "center",
              paddingLeft: 22,
            }}
          >
            <TextInput
              placeholder="Enter your email address"
              placeholderTextColor={COLORS.black}
              keyboardType="email-address"
              style={{
                width: "100%",
              }}
              value={email}
              onChangeText={(text) => setEmail(text)}
            />
          </View>
        </View>

        <View style={{ marginBottom: 12 }}>
          <Text
            style={{
              fontSize: 16,
              fontWeight: 400,
              marginVertical: 8,
            }}
          >
            Password
          </Text>

          <View
            style={{
              width: "100%",
              height: 48,
              borderColor: COLORS.black,
              borderWidth: 1,
              borderRadius: 8,
              flexDirection: 'row',
              alignItems: "center",
              paddingLeft: 22,
            }}
          >
            <TextInput
              placeholder="Enter your password"
              placeholderTextColor={COLORS.black}
              secureTextEntry={!isPasswordShown}
              style={{
                flex: 1,
              }}
              value={password}
              onChangeText={(text) => setPassword(text)}
            />

            <TouchableOpacity
              onPress={() => setIsPasswordShown(!isPasswordShown)}
              style={{
                marginRight: 12,
              }}
            >
              {isPasswordShown ? (
                <Ionicons name="eye-off" size={20} color={COLORS.black} />
              ) : (
                <Ionicons name="eye" size={20} color={COLORS.black} />
              )}
            </TouchableOpacity>
          </View>
        </View>

        <View
          style={{
            flexDirection: "row",
            marginVertical: 6,
          }}
        >
          <Checkbox
            style={{ marginRight: 8 }}
            value={isChecked}
            onValueChange={setIsChecked}
            color={isChecked ? COLORS.primary : undefined}
          />

          <Text>Remember Me</Text>
        </View>

        <Button
          title="Login"
          filled
          onPress={_userLogin}
          style={{
            marginTop: 18,
            marginBottom: 4,
          }}
        />

        <View>
          <View
            style={{
              flex: 1,
              height: 1,
              backgroundColor: COLORS.grey,
              marginHorizontal: 10,
            }}
          />
          <View
            style={{
              flex: 1,
              height: 1,
              backgroundColor: COLORS.grey,
              marginHorizontal: 10,
            }}
          />
        </View>
        <View
          style={{
            flexDirection: "row",
            justifyContent: "center",
          }}
        >
        </View>
      </View>
    </SafeAreaView>
  );
};

export default Login;