import { useGLTF } from '@react-three/drei';

export default function CoffeeTable() {
    const { scene } = useGLTF('/models/livingroomtable.glb');

    return <primitive object={scene} scale={2} position={[4, -3.9, -3]} />;
}