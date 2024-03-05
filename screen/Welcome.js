import { View, Text, Image, TouchableOpacity, Pressable } from "react-native";
import React from "react";
import { LinearGradient } from "expo-linear-gradient";
import COLORS from "../constants/colors"; // Đảm bảo import COLORS nếu sử dụng

const Welcome = ({ navigation }) => {
  return (
    <LinearGradient
      style={{
        flex: 1,  
      }}
      colors={['#96E9C6', '#86A7FC']} // Gradient từ 96E9C6 đến 83C0C1
      start={{x: 0, y: 0}} // Điểm bắt đầu của gradient (góc trái ở trên)
      end={{x: 1, y: 0}}
    >
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        
        <View>
          {/* Logo */} 
          <View>
            <Text 
              style={{
                fontSize: 25,
                color: '#9681EB', // Màu chữ là trắng
                fontWeight: 'bold',
                textAlign: "center",
                marginTop: -15,
              }}
            >
              Autonomous Car
            </Text>
          </View>
          {/* Image */}
          <Image
            source={require("../Image/logo.png")}
            style={{
              width: 170,
              height: 150,
              textAlign: "center"
            }}
          />
        </View>

        <View>
          <Text 
            style={{
              fontSize: 32,
              color: 'white', // Màu chữ là trắng
              marginTop: 15,
            }}
          >
            Let's Get Started!
          </Text>
        </View>

        {/* Nội dung */}

        <View>
          <Text 
            style={{
              fontSize: 14,
              color: 'white', // Màu chữ là trắng
              marginLeft: 20,
              marginRight: 20,
              marginTop: 5,
            }}
          >
            This application is used to monitor a competition 
            for autonomous vehicles on predefined maps for
            fruit harvesting.
          </Text>
        </View>
        {/* Button Signup */}
        <TouchableOpacity
          style={{
            backgroundColor: 'white',
            marginTop: 22,
            width: "80%",
            paddingVertical: 10,
            alignItems: 'center',
            borderRadius: 8
          }}
          onPress={() => navigation.navigate("Signup")}
        >
          <Text style={{ color: '#9681EB', fontSize: 16, fontStyle: "bold" }}>Join Now</Text>
        </TouchableOpacity>

        <View style={{
          flexDirection: "row",
          marginTop: 12,
          justifyContent: "center"
        }}>
          <Text style={{
            fontSize: 16,
            color: COLORS.white
          }}>Already have an account ?</Text>
          <Pressable
            onPress={() => navigation.navigate("Login")}
          >
            <Text style={{
              fontSize: 16,
              color: "#9681EB",
              fontWeight: "bold",
              marginLeft: 4
            }}>Login</Text>
            
          </Pressable>
        </View>
      </View>
    </LinearGradient>
  );
};

export default Welcome;
